using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Moq;

using Shouldly;

using TaskManagement.Domain.Queries;
using TaskManagement.Domain.Repositories;

using DatabaseTask = TaskManagement.Domain.Models.Database.Task;
using DatabaseUser = TaskManagement.Domain.Models.Database.User;
using ContractsTaskStatus = TaskManagement.Contracts.Models.TaskStatus;
using ContractsTask = TaskManagement.Contracts.Models.Task;
using Microsoft.Extensions.Logging;

namespace TaskManagement.UnitTests.Queries
{
    public class GetTaskByIdQueryHandlerTests
    {
        private readonly Mock<IRepository> _repositoryMock = new();
        private readonly Mock<IMapper> _mapperMock = new();

        private readonly IRequestHandler<GetTaskByIdQuery, GetTaskByIdResult> _handler;

        public GetTaskByIdQueryHandlerTests()
        {
            _handler = new GetTaskByIdQueryHandler(
                _repositoryMock.Object,
                _mapperMock.Object,
                Mock.Of<ILogger<GetTaskByIdQueryHandler>>()
            );
        }

        [Fact]
        public async Task HandleShouldReturnResultWithoutTask()
        {
            // Arrange
            _ = _repositoryMock.Setup(x => x.GetTaskById(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<DatabaseTask>(null));

            _ = _mapperMock.Setup(x => x.Map<ContractsTask>(null))
                .Returns((ContractsTask)null);

            GetTaskByIdQuery query = new() { Id = Guid.NewGuid().ToString() };

            // Act
            GetTaskByIdResult result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            _ = result.ShouldNotBeNull();
            result.Task.ShouldBeNull();
        }

        [Fact]
        public async Task HandleShouldReturnResultWithTask()
        {
            // Arrange
            string id = Guid.NewGuid().ToString();
            string title = Guid.NewGuid().ToString();
            string description = Guid.NewGuid().ToString();
            DateTime createdAt = DateTime.UtcNow;
            DateTime updatedAt = DateTime.UtcNow;
            int status = (int)ContractsTaskStatus.Completed;
            string assigneeEmail = Guid.NewGuid().ToString();

            _ = _repositoryMock.Setup(x => x.GetTaskById(id, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new DatabaseTask
                {
                    Id = Guid.Parse(id),
                    Title = title,
                    Description = description,
                    CreatedAt = createdAt,
                    UpdatedAt = updatedAt,
                    Status = status,
                    Assignee = new DatabaseUser
                    {
                        Email = assigneeEmail
                    }
                }));

            _ = _mapperMock.Setup(x => x.Map<ContractsTask>(It.IsAny<DatabaseTask>()))
                .Returns(new ContractsTask
                {
                    Id = id,
                    Title = title,
                    Description = description,
                    CreatedAt = createdAt,
                    UpdatedAt = updatedAt,
                    Status = (ContractsTaskStatus)status,
                    AssigneeEmail = assigneeEmail
                });

            GetTaskByIdQuery query = new() { Id = id };

            // Act
            GetTaskByIdResult result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            _ = result.ShouldNotBeNull();
            _ = result.Task.ShouldNotBeNull();
            result.Task.Id.ShouldBe(id);
            result.Task.Title.ShouldBe(title);
            result.Task.Description.ShouldBe(description);
            result.Task.CreatedAt.ShouldBe(createdAt);
            result.Task.UpdatedAt.ShouldBe(updatedAt);
            result.Task.Status.ShouldBe((ContractsTaskStatus)status);
            result.Task.AssigneeEmail.ShouldBe(assigneeEmail);
        }
    }
}