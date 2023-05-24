using System;
using System.Threading;
using System.Threading.Tasks;
using FinanceManagement.Domain.Models.Database;
using FinanceManagement.Context;
using FinanceManagement.Domain.Helpers;
using MediatR;
using FinanceManagement.Domain.Repositories;

using DatabaseAccounting = FinanceManagement.Domain.Models.Database.Accounting;
using FinanceManagement.Domain.Exceptions;

namespace AccountingManagement.Domain.Commands
{
    public class UpdateAccountingValueCommand : IRequest<UpdateAccountingValueResult>
    {
        public string AccountingId {get; init;}
        public int Value {get;init;}
    }

    public class UpdateAccountingValueResult
    {
    }

    internal class UpdateAccountingValueCommandHandler : IRequestHandler<UpdateAccountingValueCommand, UpdateAccountingValueResult>
    {
        private readonly IRepository _repository;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IIdentifierGenerator _identifierGenerator;

        public UpdateAccountingValueCommandHandler(IRepository repository, IDateTimeProvider dateTimeProvider, IIdentifierGenerator identifierGenerator)
        {
            _repository = repository;
            _dateTimeProvider = dateTimeProvider;
            _identifierGenerator = identifierGenerator;
        }

        public async Task<UpdateAccountingValueResult> Handle(UpdateAccountingValueCommand request, CancellationToken cancellationToken)
        {
            
            DatabaseAccounting accounting = await _repository.GetAccountingById(request.AccountingId, cancellationToken);

            if (accounting is null)
            {
                throw new FinanceManagementException(
                    FinanceManagementError.AccountingNotFound,
                    $"Accounting with id {request.AccountingId} not found"
                );
            }

            await _repository.UpdateAccountingValue(request.AccountingId, request.Value, cancellationToken);

            return new();
        }
    }
}