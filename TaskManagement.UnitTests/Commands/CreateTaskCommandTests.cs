using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Moq;

using TaskManagement.Domain.Commands;
using TaskManagement.Domain.Helpers;
using TaskManagement.Domain.Repositories;

using DatabaseTask = TaskManagement.Domain.Models.Database.Task;

namespace TaskManagement.UnitTests.Commands
{
    public class CreateTaskCommandTests
    {
        private readonly Mock<IRepository> _repositoryMock = new();
        private readonly Mock<IDateTimeProvider> _dateTimeProviderMock = new();
        private readonly Mock<IIdentifierGenerator> _identifierGeneratorMock = new();

        private readonly IRequestHandler<CreateTaskCommand, CreateTaskResult> _handler;

        public CreateTaskCommandTests()
        {
            _handler = new CreateTaskCommandHandler(
                _repositoryMock.Object,
                _dateTimeProviderMock.Object,
                _identifierGeneratorMock.Object
            );
        }

        [Fact]
        public async Task HandleShouldAddTaskToRepository()
        {
            // Arrange
            string title = Guid.NewGuid().ToString();
            string description = Guid.NewGuid().ToString();

            CreateTaskCommand command = new()
            {
                Title = title,
                Description = description
            };

            DateTime now = DateTime.Now;
            _ = _dateTimeProviderMock.Setup(x => x.Now).Returns(now);

            Guid id = Guid.NewGuid();
            _ = _identifierGeneratorMock.Setup(x => x.Generate()).Returns(id);

            // Act
            _ = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _repositoryMock.Verify(x => x.AddTask(It.Is<DatabaseTask>(t => t.Assignee == null &&
                t.AssigneeId == null &&
                t.Description == description &&
                t.Status == 0 &&
                t.Title == title &&
                t.UpdatedAt == null &&
                t.CreatedAt == now &&
                t.Id == id), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}