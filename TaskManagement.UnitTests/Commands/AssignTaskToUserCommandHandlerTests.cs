using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.Extensions.Logging;

using Moq;

using TaskManagement.Domain.Commands;
using TaskManagement.Domain.Exceptions;
using TaskManagement.Domain.Repositories;

using DatabaseTask = TaskManagement.Domain.Models.Database.Task;
using DatabaseUser = TaskManagement.Domain.Models.Database.User;
using ContractsTaskStatus = TaskManagement.Contracts.Models.TaskStatus;

namespace TaskManagement.UnitTests.Commands
{
    public class AssignTaskToUserCommandHandlerTests
    {
        private readonly Mock<IRepository> _repositoryMock = new();

        private readonly IRequestHandler<AssignTaskToUserCommand, AssignTaskToUserCommandResult> _handler;

        public AssignTaskToUserCommandHandlerTests()
        {
            _handler = new AssignTaskToUserCommandHandler(
                _repositoryMock.Object,
                Mock.Of<ILogger<AssignTaskToUserCommandHandler>>()
            );
        }

        [Theory]
        [InlineData(ContractsTaskStatus.Assigned)]
        [InlineData(ContractsTaskStatus.InProgress)]
        [InlineData(ContractsTaskStatus.Completed)]
        [InlineData(ContractsTaskStatus.Cancelled)]
        public async Task HandleShouldThrowExceptionIfTaskStatusIsNotNew(ContractsTaskStatus status)
        {
            // Arrange
            DatabaseTask task = new()
            {
                Id = Guid.NewGuid(),
                Status = (int)status
            };

            _ = _repositoryMock.Setup(x => x.GetTaskById(task.Id.ToString(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(task));

            // Act
            Task Action()
            {
                return _handler.Handle(new AssignTaskToUserCommand { TaskId = task.Id.ToString() }, CancellationToken.None);
            }

            // Assert
            _ = await Assert.ThrowsAsync<TaskManagementException>(Action);
        }

        [Fact]
        public async Task HandleShouldThrowExceptionIfTaskDoesNotExist()
        {
            // Arrange
            Guid taskId = Guid.NewGuid();

            _ = _repositoryMock.Setup(x => x.GetTaskById(taskId.ToString(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<DatabaseTask>(null));

            // Act
            Task Action()
            {
                return _handler.Handle(new AssignTaskToUserCommand { TaskId = taskId.ToString() }, CancellationToken.None);
            }

            // Assert
            _ = await Assert.ThrowsAsync<TaskManagementException>(Action);
        }

        [Fact]
        public async Task HandleShouldThrowExceptionIfTaskIsAlreadyAssignedToUser()
        {
            // Arrange
            DatabaseTask task = new()
            {
                Id = Guid.NewGuid(),
                Status = (int)ContractsTaskStatus.New,
                AssigneeId = 42
            };

            _ = _repositoryMock.Setup(x => x.GetTaskById(task.Id.ToString(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(task));

            // Act
            Task Action()
            {
                return _handler.Handle(new AssignTaskToUserCommand { TaskId = task.Id.ToString() }, CancellationToken.None);
            }

            // Assert
            _ = await Assert.ThrowsAsync<TaskManagementException>(Action);
        }

        [Fact]
        public async Task HandleShouldAssignTaskToUser()
        {
            // Arrange
            DatabaseTask task = new()
            {
                Id = Guid.NewGuid(),
                Status = (int)ContractsTaskStatus.New
            };

            long userId = 42;

            _ = _repositoryMock.Setup(x => x.GetTaskById(task.Id.ToString(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(task));

            _ = _repositoryMock.Setup(x => x.CreateUserIfNotExists(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new DatabaseUser { Id = userId }));

            // Act
            AssignTaskToUserCommandResult result = await _handler.Handle(new AssignTaskToUserCommand { TaskId = task.Id.ToString() }, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            _repositoryMock.Verify(x => x.AssignToUser(task.Id.ToString(), userId, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}