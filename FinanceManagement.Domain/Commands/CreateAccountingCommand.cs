using System;
using System.Threading;
using System.Threading.Tasks;
using FinanceManagement.Domain.Models.Database;
using FinanceManagement.Context;
using FinanceManagement.Domain.Helpers;
using MediatR;
using FinanceManagement.Domain.Repositories;


namespace AccountingManagement.Domain.Commands
{
    public class CreateAccountingCommand : IRequest<CreateAccountingResult>
    {
        public string Title {get;init;}
        public int Value {get;init;}
    }

    public class CreateAccountingResult
    {
        public string Id {get;init;}
    }

    internal class CreateAccountingCommandHandler : IRequestHandler<CreateAccountingCommand, CreateAccountingResult>
    {
        private readonly IRepository _repository;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IIdentifierGenerator _identifierGenerator;

        public CreateAccountingCommandHandler(IRepository repository, IDateTimeProvider dateTimeProvider, IIdentifierGenerator identifierGenerator)
        {
            _repository = repository;
            _dateTimeProvider = dateTimeProvider;
            _identifierGenerator = identifierGenerator;
        }

        public async Task<CreateAccountingResult> Handle(CreateAccountingCommand request, CancellationToken cancellationToken)
        {
            var accounting = new Accounting
            {
                Title = request.Title,
                Value = request.Value,
                CreatedAt = _dateTimeProvider.Now,
                Id = _identifierGenerator.Generate()
            };

            await _repository.AddAccounting(accounting, cancellationToken);

            return new CreateAccountingResult
            {
                Id = accounting.Id.ToString()
            };
        }


    }
}