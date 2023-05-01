using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Moq;

using Shouldly;

using TaskManagement.Domain.DbContexts;
using TaskManagement.Domain.Helpers;
using TaskManagement.Domain.Repositories;

using DatabaseTask = TaskManagement.Domain.Models.Database.Task;
using DatabaseUser = TaskManagement.Domain.Models.Database.User;
using ContractsTaskStatus = TaskManagement.Contracts.Models.TaskStatus;

namespace TaskManagement.IntegrationTests
{
    public class RepositoryTests
    {
        private readonly IRepository _repository;

        private readonly Mock<IDateTimeProvider> _dateTimeProviderMock = new();
        private readonly Mock<IIdentifierGenerator> _identifierGeneratorMock = new();

        public RepositoryTests()
        {
            _repository = new Repository(
                CreateContext(),
                _dateTimeProviderMock.Object,
                _identifierGeneratorMock.Object
            );
        }

        [Fact]
        public async Task CreateTaskShouldDoItSuccessfully()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            DateTime now = DateTime.UtcNow;

            string title = Guid.NewGuid().ToString();
            string description = Guid.NewGuid().ToString();

            _ = _dateTimeProviderMock.SetupGet(m => m.Now).Returns(now);
            _ = _identifierGeneratorMock.Setup(m => m.Generate()).Returns(id);

            // Act
            DatabaseTask result = await _repository.CreateTask(title, description);

            await using TaskManagementContext testContext = CreateContext();
            bool taskExist = await testContext.Tasks.AnyAsync(x => x.Id == id);

            // Assert
            taskExist.ShouldBeTrue();

            result.Id.ShouldBe(id);
            result.CreatedAt.ShouldBe(now);
            result.Title.ShouldBe(title);
            result.Description.ShouldBe(description);
        }

        [Fact]
        public async Task GetTaskByIdShouldReturnTaskWithoutAssignee()
        {
            // Arrange
            DatabaseTask task = new()
            {
                Id = Guid.NewGuid(),
                CreatedAt = new DateTime(2021, 1, 1, 2, 3, 4, DateTimeKind.Utc),
                Title = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Status = 3,
                UpdatedAt = new DateTime(2022, 2, 3, 4, 5, 6, DateTimeKind.Utc),
            };

            await using TaskManagementContext testContext = CreateContext();
            _ = await testContext.Tasks.AddAsync(task);
            _ = await testContext.SaveChangesAsync();

            // Act
            DatabaseTask result = await _repository.GetTaskById(task.Id.ToString());

            // Assert
            _ = result.ShouldNotBeNull();
            result.Id.ShouldBe(task.Id);
            result.CreatedAt.ShouldBe(task.CreatedAt);
            result.Title.ShouldBe(task.Title);
            result.Description.ShouldBe(task.Description);
            result.AssigneeId.ShouldBeNull();
            result.Assignee.ShouldBeNull();
            result.Status.ShouldBe(task.Status);
            result.UpdatedAt.ShouldBe(task.UpdatedAt);
        }

        [Fact]
        public async Task GetTaskByIdShouldReturnTaskWithAssignee()
        {
            // Arrange
            DatabaseTask task = new()
            {
                Id = Guid.NewGuid(),
                CreatedAt = new DateTime(2021, 1, 1, 2, 3, 4, DateTimeKind.Utc),
                Title = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Assignee = new DatabaseUser
                {
                    Email = $"{Guid.NewGuid():N}@example.com",
                },
                Status = 3,
                UpdatedAt = new DateTime(2022, 2, 3, 4, 5, 6, DateTimeKind.Utc),
            };

            await using TaskManagementContext testContext = CreateContext();
            _ = await testContext.Tasks.AddAsync(task);
            _ = await testContext.SaveChangesAsync();

            // Act
            DatabaseTask result = await _repository.GetTaskById(task.Id.ToString());

            // Assert
            _ = result.ShouldNotBeNull();
            result.Id.ShouldBe(task.Id);
            result.CreatedAt.ShouldBe(task.CreatedAt);
            result.Title.ShouldBe(task.Title);
            result.Description.ShouldBe(task.Description);
            result.AssigneeId.ShouldBe(task.AssigneeId);
            _ = result.Assignee.ShouldNotBeNull();
            result.Assignee.Email.ShouldBe(task.Assignee.Email);
            result.Status.ShouldBe(task.Status);
            result.UpdatedAt.ShouldBe(task.UpdatedAt);
        }

        [Fact]
        public async Task GetTaskByIdShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            DatabaseTask result = await _repository.GetTaskById(id.ToString());

            // Assert
            result.ShouldBeNull();
        }

        [Fact]
        public async Task CreateUserIfNotExistsShouldCreateUser()
        {
            // Arrange
            string email = $"{Guid.NewGuid():N}@gmail.com";

            // Act
            DatabaseUser result = await _repository.CreateUserIfNotExists(email);

            await using TaskManagementContext testContext = CreateContext();
            bool userExist = await testContext.Users.AnyAsync(x => x.Email == email);

            // Assert
            userExist.ShouldBeTrue();
        }

        [Fact]
        public async Task CreateUserIfNotExistsShouldReturnUser()
        {
            // Arrange
            DatabaseUser user = new()
            {
                Email = $"{Guid.NewGuid():N}@gmail.com",
            };

            await using TaskManagementContext testContext = CreateContext();
            _ = await testContext.Users.AddAsync(user);
            _ = await testContext.SaveChangesAsync();

            // Act
            DatabaseUser result = await _repository.CreateUserIfNotExists(user.Email);

            // Assert
            _ = result.ShouldNotBeNull();
            result.Id.ShouldBe(user.Id);
        }

        [Fact]
        public async Task AssignToUserShouldDoItSuccessfully()
        {
            // Arrange
            DatabaseTask task = new()
            {
                Id = Guid.NewGuid(),
                CreatedAt = new DateTime(2021, 1, 1, 2, 3, 4, DateTimeKind.Utc),
                Title = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                UpdatedAt = new DateTime(2022, 2, 3, 4, 5, 6, DateTimeKind.Utc),
            };

            DatabaseUser user = new()
            {
                Email = $"{Guid.NewGuid():N}@gmail.com"
            };

            await using TaskManagementContext testContext = CreateContext();
            _ = await testContext.Tasks.AddAsync(task);
            _ = await testContext.Users.AddAsync(user);
            _ = await testContext.SaveChangesAsync();

            // Act
            await _repository.AssignToUser(task.Id.ToString(), user.Id);

            await using TaskManagementContext testContext2 = CreateContext();
            DatabaseTask result = await testContext2.Tasks
                .Include(x => x.Assignee)
                .FirstOrDefaultAsync(x => x.Id == task.Id);

            // Assert
            _ = result.ShouldNotBeNull();
            result.AssigneeId.ShouldBe(user.Id);
            result.Assignee.Id.ShouldBe(user.Id);
            result.Assignee.Email.ShouldBe(user.Email);
            result.Status.ShouldBe((int)ContractsTaskStatus.Assigned);
        }

        private static TaskManagementContext CreateContext()
        {
            DbContextOptions<TaskManagementContext> options = new DbContextOptionsBuilder<TaskManagementContext>()
                .UseNpgsql("Host=localhost;Database=task_management;Username=user;Password=password")
                .Options;

            return new TaskManagementContext(options);
        }
    }
}