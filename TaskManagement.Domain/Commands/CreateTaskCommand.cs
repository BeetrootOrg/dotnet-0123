using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.Extensions.Logging;

using TaskManagement.Domain.Base;
using TaskManagement.Domain.Repositories;

using DatabaseTask = TaskManagement.Domain.Models.Database.Task;

namespace TaskManagement.Domain.Commands
{
    public class CreateTaskCommand : IRequest<CreateTaskResult>
    {
        public string Title { get; init; }
        public string Description { get; init; }
    }

    public class CreateTaskResult
    {
        public string Id { get; init; }
    }

    internal class CreateTaskCommandHandler : BaseRequestHandler<CreateTaskCommand, CreateTaskResult>
    {
        private readonly IRepository _repository;

        public CreateTaskCommandHandler(IRepository repository, ILogger<CreateTaskCommandHandler> logger) : base(logger)
        {
            _repository = repository;
        }

        protected override async Task<CreateTaskResult> HandleInternal(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            DatabaseTask task = await _repository.CreateTask(request.Title, request.Description, cancellationToken);
            return new CreateTaskResult
            {
                Id = task.Id.ToString()
            };
        }
    }
}