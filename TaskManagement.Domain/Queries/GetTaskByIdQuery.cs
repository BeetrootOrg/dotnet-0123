using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using TaskManagement.Domain.Repositories;

using DatabaseTask = TaskManagement.Domain.Models.Database.Task;
using ContractsTask = TaskManagement.Contracts.Models.Task;
using TaskManagement.Domain.Base;
using Microsoft.Extensions.Logging;

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

    internal class GetTaskByIdQueryHandler : BaseRequestHandler<GetTaskByIdQuery, GetTaskByIdResult>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetTaskByIdQueryHandler(IRepository repository, IMapper mapper, ILogger<GetTaskByIdQueryHandler> logger) : base(logger)
        {
            _repository = repository;
            _mapper = mapper;
        }

        protected override async Task<GetTaskByIdResult> HandleInternal(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            DatabaseTask dbResult = await _repository.GetTaskById(request.Id, cancellationToken);
            return new GetTaskByIdResult
            {
                Task = _mapper.Map<ContractsTask>(dbResult)
            };
        }
    }
}