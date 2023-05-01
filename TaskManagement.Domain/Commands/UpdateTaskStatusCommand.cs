using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.Extensions.Logging;

using TaskManagement.Domain.Base;
using TaskManagement.Domain.Exceptions;
using TaskManagement.Domain.Repositories;

using DatabaseTask = TaskManagement.Domain.Models.Database.Task;
using ContractsTaskStatus = TaskManagement.Contracts.Models.TaskStatus;

namespace TaskManagement.Domain.Commands
{
    public class UpdateTaskStatusCommand : IRequest<UpdateTaskStatusResult>
    {
        public string TaskId { get; init; }
        public ContractsTaskStatus Status { get; init; }
    }

    public class UpdateTaskStatusResult
    {
    }

    internal class UpdateTaskStatusCommandHandler : BaseRequestHandler<UpdateTaskStatusCommand, UpdateTaskStatusResult>
    {
        private static readonly IDictionary<ContractsTaskStatus, ContractsTaskStatus[]> AllowedStatuses =
            new ReadOnlyDictionary<ContractsTaskStatus, ContractsTaskStatus[]>(
                new Dictionary<ContractsTaskStatus, ContractsTaskStatus[]>
                {
                    { ContractsTaskStatus.New, new[] { ContractsTaskStatus.Cancelled } },
                    { ContractsTaskStatus.Assigned, new[] { ContractsTaskStatus.InProgress, ContractsTaskStatus.Cancelled } },
                    { ContractsTaskStatus.InProgress, new[] { ContractsTaskStatus.Completed, ContractsTaskStatus.Cancelled } },
                }
            );

        private readonly IRepository _repository;

        public UpdateTaskStatusCommandHandler(IRepository repository, ILogger<UpdateTaskStatusCommandHandler> logger) : base(logger)
        {
            _repository = repository;
        }

        protected override async Task<UpdateTaskStatusResult> HandleInternal(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
        {
            DatabaseTask task = await _repository.GetTaskById(request.TaskId, cancellationToken);
            if (task is null)
            {
                throw new TaskManagementException(
                    TaskManagementError.TaskNotFound,
                    $"Task with id {request.TaskId} not found"
                );
            }

            if (!AllowedStatuses.TryGetValue((ContractsTaskStatus)task.Status, out ContractsTaskStatus[] allowedStatuses))
            {
                throw new TaskManagementException(
                    TaskManagementError.TaskStatusCannotBeChanged,
                    $"Task status cannot be changed from {(ContractsTaskStatus)task.Status}"
                );
            }

            if (!Array.Exists(allowedStatuses, status => status == request.Status))
            {
                throw new TaskManagementException(
                    TaskManagementError.TaskStatusCannotBeChanged,
                    $"Task status cannot be changed from {(ContractsTaskStatus)task.Status} to {request.Status}"
                );
            }

            await _repository.UpdateTaskStatus(request.TaskId, request.Status, cancellationToken);
            return new();
        }
    }
}