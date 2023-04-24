using System.Threading;
using System.Threading.Tasks;

using MediatR;

using TaskManagement.Domain.Helpers;
using TaskManagement.Domain.Repositories;

using DatabaseTask = TaskManagement.Domain.Models.Database.Task;
using DatabaseTaskStatus = TaskManagement.Contracts.Models.TaskStatus;

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
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IIdentifierGenerator _identifierGenerator;

        public CreateTaskCommandHandler(IRepository repository,
            IDateTimeProvider dateTimeProvider,
            IIdentifierGenerator identifierGenerator)
        {
            _repository = repository;
            _dateTimeProvider = dateTimeProvider;
            _identifierGenerator = identifierGenerator;
        }

        public async Task<CreateTaskResult> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            DatabaseTask task = new()
            {
                Title = request.Title,
                Description = request.Description,
                CreatedAt = _dateTimeProvider.Now,
                Status = (int)DatabaseTaskStatus.New,
                Id = _identifierGenerator.Generate()
            };

            await _repository.AddTask(task, cancellationToken);

            return new CreateTaskResult
            {
                Id = task.Id.ToString()
            };
        }
    }
}