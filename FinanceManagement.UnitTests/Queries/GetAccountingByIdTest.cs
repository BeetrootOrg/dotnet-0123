using MediatR;
using System;

using Moq;

using Shouldly;

using FinanceManagement.Domain.Queries;
using FinanceManagement.Domain.Repositories;
using System.Threading.Tasks;
using System.Threading;

using DatabaseAccounting = FinanceManagement.Domain.Models.Database.Accounting;

using DatabaseUser = FinanceManagement.Domain.Models.Database.User;

namespace FinanceManagement.UnitTests.Queries
{

        public class GetAccountingByIdQueryTests
    {
        private readonly Mock<IRepository> _repositoryMock = new();
        private readonly IRequestHandler<GetAccountingByIdQuery, GetAccountingByIdResult> _handler;

        public GetAccountingByIdQueryTests()
        {
            _handler = new GetAccountingByIdQueryHandler(_repositoryMock.Object);
        }

        [Fact]

        public async Task HandleShouldReturnResultWithoutAccounting()
        {
            _repositoryMock.Setup(x => x.GetAccountingById(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult<DatabaseAccounting>(null));

            
            var query = new GetAccountingByIdQuery {Id = Guid.NewGuid().ToString()};

            GetAccountingByIdResult result = await _handler.Handle(query, CancellationToken.None);

            result.ShouldNotBeNull();
            result.Accounting.ShouldBeNull();
        }

        [Fact]
        public async Task HandleShouldReturnResultWithAccounting()
        {


            Random r = new Random();
            int value = r.Next(0, 1000);
            string id = Guid.NewGuid().ToString();
            DateTime createdAt = DateTime.UtcNow;
            string assigneeEmail = Guid.NewGuid().ToString();
            string title = "1";

            _repositoryMock.Setup(x => x.GetAccountingById(id, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new DatabaseAccounting
                {
                    Id = Guid.Parse(id),
                    Title = title,
                    Value = value,
                    Created_at = createdAt,
                    Assignee = new DatabaseUser
                    {
                        Email = assigneeEmail
                    }
                }));

            GetAccountingByIdQuery query = new() { Id = id };

            // Act
            GetAccountingByIdResult result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            _ = result.ShouldNotBeNull();
            _ = result.Accounting.ShouldNotBeNull();
            result.Accounting.Id.ShouldBe(id);
            result.Accounting.Title.ShouldBe(title);
            result.Accounting.Value.ShouldBe(value);
            result.Accounting.Created_at.ShouldBe(createdAt);
            result.Accounting.AssigneeEmail.ShouldBe(assigneeEmail);
        }
    }
}
