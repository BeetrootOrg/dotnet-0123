using System.Threading;
using System.Threading.Tasks;

using MediatR;

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

    internal class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, CreateTaskResult>
    {
        private readonly IRepository _repository;

        public CreateTaskCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateTaskResult> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            DatabaseTask task = await _repository.CreateTask(request.Title, request.Description, cancellationToken);

            return new CreateTaskResult
            {
                Id = task.Id.ToString()
            };
        }
    }
}