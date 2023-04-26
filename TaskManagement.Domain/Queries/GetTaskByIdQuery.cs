using System.Threading;
using System.Threading.Tasks;

using MediatR;

using TaskManagement.Domain.Repositories;

using DatabaseTask = TaskManagement.Domain.Models.Database.Task;
using ContractsTaskStatus = TaskManagement.Contracts.Models.TaskStatus;
using ContractsTask = TaskManagement.Contracts.Models.Task;

namespace TaskManagement.Domain.Queries
{
    public class GetTaskByIdQuery : IRequest<GetTaskByIdResult>
    {
        public string Id { get; init; }
    }

    public class GetTaskByIdResult
    {
        public ContractsTask Task { get; init; }
    }

    internal class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, GetTaskByIdResult>
    {
        private readonly IRepository _repository;

        public GetTaskByIdQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetTaskByIdResult> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            DatabaseTask dbResult = await _repository.GetTaskById(request.Id, cancellationToken);

            return dbResult == null
                ? new GetTaskByIdResult()
                : new GetTaskByIdResult
                {
                    Task = new ContractsTask
                    {
                        Id = dbResult.Id.ToString(),
                        Title = dbResult.Title,
                        Description = dbResult.Description,
                        CreatedAt = dbResult.CreatedAt,
                        UpdatedAt = dbResult.UpdatedAt,
                        Status = (ContractsTaskStatus)dbResult.Status,
                        AssigneeEmail = dbResult.Assignee?.Email
                    }
                };
        }
    }
}