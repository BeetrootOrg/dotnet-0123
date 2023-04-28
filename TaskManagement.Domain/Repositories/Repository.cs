using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TaskManagement.Domain.DbContexts;
using TaskManagement.Domain.Exceptions;
using TaskManagement.Domain.Helpers;

using DatabaseTask = TaskManagement.Domain.Models.Database.Task;
using DatabaseUser = TaskManagement.Domain.Models.Database.User;
using ContractsTaskStatus = TaskManagement.Contracts.Models.TaskStatus;

namespace TaskManagement.Domain.Repositories
{
    internal interface IRepository
    {
        Task<DatabaseTask> CreateTask(string title, string description, CancellationToken cancellationToken = default);
        Task<DatabaseTask> GetTaskById(string id, CancellationToken cancellationToken = default);
        Task AssignToUser(string taskId, string email, CancellationToken cancellationToken = default);
    }

    internal class Repository : IRepository
    {
        private readonly TaskManagementContext _dbContext;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IIdentifierGenerator _identifierGenerator;

        public Repository(TaskManagementContext dbContext,
            IDateTimeProvider dateTimeProvider,
            IIdentifierGenerator identifierGenerator)
        {
            _dbContext = dbContext;
            _dateTimeProvider = dateTimeProvider;
            _identifierGenerator = identifierGenerator;
        }

        public async Task AssignToUser(string taskId, string email, CancellationToken cancellationToken = default)
        {
            DatabaseUser user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email, cancellationToken);
            if (user is null)
            {
                user = new DatabaseUser
                {
                    Email = email,
                };

                _ = await _dbContext.Users.AddAsync(user, cancellationToken);
                _ = await _dbContext.SaveChangesAsync(cancellationToken);
            }

            DatabaseTask task = await _dbContext.Tasks.SingleAsync(x => x.Id.ToString() == taskId, cancellationToken);
            if (task.Status != (int)ContractsTaskStatus.New)
            {
                throw new TaskManagementException(
                    TaskManagementError.TaskStatusIsNotNew,
                    $"Task status is not {ContractsTaskStatus.New} but {task.Status}"
                );
            }

            if (task.AssigneeId is not null)
            {
                throw new TaskManagementException(
                    TaskManagementError.TaskAlreadyAssignedToUser,
                    $"Task is already assigned to user with id {task.AssigneeId}"
                );
            }

            task.AssigneeId = user.Id;
            task.Status = (int)ContractsTaskStatus.Assigned;

            _ = await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<DatabaseTask> CreateTask(string title, string description,
            CancellationToken cancellationToken = default)
        {
            DatabaseTask task = new()
            {
                Title = title,
                Description = description,
                Id = _identifierGenerator.Generate(),
                CreatedAt = _dateTimeProvider.Now,
            };

            _ = await _dbContext.Tasks.AddAsync(task, cancellationToken);
            _ = await _dbContext.SaveChangesAsync(cancellationToken);

            return task;
        }

        public async Task<DatabaseUser> CreateUserIfNotExists(string email, CancellationToken cancellationToken = default)
        {
            DatabaseUser user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email, cancellationToken);
            if (user is not null)
            {
                return user;
            }

            user = new DatabaseUser
            {
                Email = email,
            };

            _ = await _dbContext.Users.AddAsync(user, cancellationToken);
            _ = await _dbContext.SaveChangesAsync(cancellationToken);

            return user;
        }

        public Task<DatabaseTask> GetTaskById(string id, CancellationToken cancellationToken = default)
        {
            return _dbContext.Tasks
                .Include(t => t.Assignee)
                .SingleOrDefaultAsync(t => t.Id.ToString() == id, cancellationToken);
        }
    }
}