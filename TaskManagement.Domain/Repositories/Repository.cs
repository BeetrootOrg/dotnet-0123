using System.Threading;
using System.Threading.Tasks;

using TaskManagement.Domain.DbContexts;

using DatabaseTask = TaskManagement.Domain.Models.Database.Task;

namespace TaskManagement.Domain.Repositories
{
    internal interface IRepository
    {
        Task AddTask(DatabaseTask task, CancellationToken cancellationToken = default);
    }

    internal class Repository : IRepository
    {
        private readonly TaskManagementContext _dbContext;

        public Repository(TaskManagementContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddTask(DatabaseTask task, CancellationToken cancellationToken = default)
        {
            _ = await _dbContext.Tasks.AddAsync(task, cancellationToken);
            _ = await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}