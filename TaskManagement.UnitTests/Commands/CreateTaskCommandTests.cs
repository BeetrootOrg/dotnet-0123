using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Moq;

using Shouldly;

using TaskManagement.Domain.Commands;
using TaskManagement.Domain.Repositories;

using DatabaseTask = TaskManagement.Domain.Models.Database.Task;

namespace TaskManagement.UnitTests.Commands
{
    public class CreateTaskCommandTests
    {
        private readonly Mock<IRepository> _repositoryMock = new();

        private readonly IRequestHandler<CreateTaskCommand, CreateTaskResult> _handler;

        public CreateTaskCommandTests()
        {
            _handler = new CreateTaskCommandHandler(_repositoryMock.Object);
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

            Guid id = Guid.NewGuid();

            _ = _repositoryMock.Setup(x => x.CreateTask(title, description, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new DatabaseTask
                {
                    Id = id
                }));

            // Act
            CreateTaskResult result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Id.ShouldBe(id.ToString());
        }
    }
}