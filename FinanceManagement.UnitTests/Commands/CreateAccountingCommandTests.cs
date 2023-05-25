using System;
using System.Threading;

using AccountingManagement.Domain.Commands;
using FinanceManagement.Domain.Helpers;
using FinanceManagement.Domain.Repositories;

using MediatR;

using DatabaseTask = FinanceManagement.Domain.Models.Database.Accounting;

using Moq;
using System.Threading.Tasks;

namespace FinanceManagement.UnitTests.Commands
{
    public class CreateAccountingCommandTests
    {

        private readonly Mock<IRepository> _repositoryMock = new();

        private readonly Mock<IIdentifierGenerator> _identifierGeneratorMock = new();
        private readonly Mock<IDateTimeProvider> _dateTimeProviderMock = new();
        private readonly IRequestHandler<CreateAccountingCommand, CreateAccountingResult> _handler;



        public CreateAccountingCommandTests()
        {
            _handler = new  CreateAccountingCommandHandler(_repositoryMock.Object, _dateTimeProviderMock.Object, _identifierGeneratorMock.Object);
        }

        [Fact]

        public async Task HandleShouldAddAccountingToRepository()
        {
            Random r = new Random();
            string title = Guid.NewGuid().ToString();
            int value = r.Next(0, 1000);

            CreateAccountingCommand command = new()
            {
                Title = title,
                Value = value
            };

            DateTime now = DateTime.Now;
            _dateTimeProviderMock.Setup(x => x.Now).Returns(now);

            Guid id = Guid.NewGuid();
            _identifierGeneratorMock.Setup(x => x.Generate()).Returns(id);
            
            _ = await _handler.Handle(command, CancellationToken.None);

            _repositoryMock.Verify(x => x.AddAccounting(It.Is<DatabaseTask>(t => 
            t.Value == value &&
            t.Iterations == 0 &&
            t.Title == title &&
            t.CreatedAt == now &&
            t.Id == id), It.IsAny<CancellationToken>()),Times.Once);
        }
    }
}