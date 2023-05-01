using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.Extensions.Logging;

using TaskManagement.Domain.Base;
using TaskManagement.Domain.Exceptions;
using TaskManagement.Domain.Repositories;

using DatabaseTask = TaskManagement.Domain.Models.Database.Task;
using DatabaseUser = TaskManagement.Domain.Models.Database.User;
using ContractsTaskStatus = TaskManagement.Contracts.Models.TaskStatus;

namespace TaskManagement.Domain.Commands
{
    public class AssignTaskToUserCommand : IRequest<AssignTaskToUserCommandResult>
    {
        public string TaskId { get; init; }
        public string Email { get; init; }
    }

    public class AssignTaskToUserCommandResult
    {
    }

    internal class AssignTaskToUserCommandHandler : BaseRequestHandler<AssignTaskToUserCommand, AssignTaskToUserCommandResult>
    {
        private readonly IRepository _repository;

        public AssignTaskToUserCommandHandler(IRepository repository, ILogger<AssignTaskToUserCommandHandler> logger) : base(logger)
        {
            _repository = repository;
        }

        protected override async Task<AssignTaskToUserCommandResult> HandleInternal(AssignTaskToUserCommand request, CancellationToken cancellationToken)
        {
            DatabaseTask task = await _repository.GetTaskById(request.TaskId, cancellationToken);
            if (task is null)
            {
                throw new TaskManagementException(
                    TaskManagementError.TaskNotFound,
                    $"Task with id {request.TaskId} not found"
                );
            }

            if (task.Status != (int)ContractsTaskStatus.New)
            {
                throw new TaskManagementException(
                    TaskManagementError.TaskStatusIsNotNew,
                    $"Task status is not {ContractsTaskStatus.New} but {(ContractsTaskStatus)task.Status}"
                );
            }

            if (task.AssigneeId is not null)
            {
                throw new TaskManagementException(
                    TaskManagementError.TaskAlreadyAssignedToUser,
                    $"Task is already assigned to user with id {task.AssigneeId}"
                );
            }

            DatabaseUser user = await _repository.CreateUserIfNotExists(request.Email, cancellationToken);
            await _repository.AssignToUser(task.Id.ToString(), user.Id, cancellationToken);

            return new();
        }
    }
}