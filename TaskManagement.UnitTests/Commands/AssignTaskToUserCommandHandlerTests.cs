using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.Extensions.Logging;

using Moq;

using TaskManagement.Domain.Commands;
using TaskManagement.Domain.Repositories;

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

        [Fact]
        public async Task HandleShouldAssignTaskToUser()
        {
            // Arrange
            string taskId = Guid.NewGuid().ToString();
            string email = Guid.NewGuid().ToString();

            AssignTaskToUserCommand command = new()
            {
                TaskId = taskId,
                Email = email
            };

            // Act
            AssignTaskToUserCommandResult result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _repositoryMock.Verify(x => x.AssignToUser(taskId, email, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}