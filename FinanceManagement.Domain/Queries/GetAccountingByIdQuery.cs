using System;


using Microsoft.Extensions.Logging;

using DatabaseAccounting = FinanceManagement.Domain.Models.Database.Accounting;
using ContractsAccounting = FinanceManagement.Contracts.Models.Accounting;
using MediatR;

using FinanceManagement.Domain.Repositories;
using System.Threading.Tasks;
using System.Threading;

namespace FinanceManagement.Domain.Queries
{
    public class GetAccountingByIdQuery : IRequest<GetAccountingByIdResult>
    {
        public string Id { get; init; }
    }

    public class GetAccountingByIdResult
    {
        public ContractsAccounting Accounting { get; init; }
    }

    internal class GetAccountingByIdQueryHandler : IRequestHandler<GetAccountingByIdQuery, GetAccountingByIdResult>
    {

        private readonly IRepository _repository;

        public GetAccountingByIdQueryHandler(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetAccountingByIdResult> Handle(GetAccountingByIdQuery request, CancellationToken cancellationToken)
        {
            DatabaseAccounting dbResult = await _repository.GetAccountingById(request.Id, cancellationToken);
            if (dbResult == null)
            {
                return new GetAccountingByIdResult();
            }

            return new GetAccountingByIdResult
            {
                Accounting = new ContractsAccounting
                {
                    Title = dbResult.Title,
                    Value = dbResult.Value,
                    Created_at = dbResult.CreatedAt,
                    AssigneeEmail = dbResult.Assignee?.Email,
                    Iterations = dbResult.Iterations,
                    Id = dbResult.Id.ToString()
                }
            };
        }
    }
}