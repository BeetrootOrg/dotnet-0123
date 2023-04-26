using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using TaskManagement.Domain.Repositories;

using DatabaseTask = TaskManagement.Domain.Models.Database.Task;
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
        private readonly IMapper _mapper;

        public GetTaskByIdQueryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetTaskByIdResult> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            DatabaseTask dbResult = await _repository.GetTaskById(request.Id, cancellationToken);
            return new GetTaskByIdResult
            {
                Task = _mapper.Map<ContractsTask>(dbResult)
            };
        }
    }
}