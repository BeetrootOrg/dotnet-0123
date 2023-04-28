using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.Extensions.Logging;

using TaskManagement.Domain.Base;
using TaskManagement.Domain.Repositories;

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
            await _repository.AssignToUser(request.TaskId, request.Email, cancellationToken);
            return new();
        }
    }
}