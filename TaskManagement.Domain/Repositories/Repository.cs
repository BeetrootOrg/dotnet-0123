using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TaskManagement.Domain.DbContexts;
using TaskManagement.Domain.Helpers;

using DatabaseTask = TaskManagement.Domain.Models.Database.Task;

namespace TaskManagement.Domain.Repositories
{
    internal interface IRepository
    {
        Task<DatabaseTask> CreateTask(string title, string description, CancellationToken cancellationToken = default);
        Task<DatabaseTask> GetTaskById(string id, CancellationToken cancellationToken = default);
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

        public Task<DatabaseTask> GetTaskById(string id, CancellationToken cancellationToken = default)
        {
            return _dbContext.Tasks
                .Include(t => t.Assignee)
                .SingleOrDefaultAsync(t => t.Id.ToString() == id, cancellationToken);
        }
    }
}