using System.Threading;
using System.Threading.Tasks;
using FinanceManagement.Context.DbContexts;

using Microsoft.EntityFrameworkCore;

using DatabaseAccounting = FinanceManagement.Domain.Models.Database.Accounting;

namespace FinanceManagement.Domain.Repositories
{
    internal interface IRepository
    {
        Task AddAccounting(DatabaseAccounting accounting, CancellationToken cancellationToken = default);
        Task<DatabaseAccounting> GetAccountingById(string id, CancellationToken cancellationToken = default);

        Task UpdateAccountingValue(string id, int value, CancellationToken cancellationToken = default);
    }
    internal class Repository : IRepository
    {

        private readonly FinanceManagementContext _dbContext;

        public Repository(FinanceManagementContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAccounting(DatabaseAccounting accounting, CancellationToken cancellationToken = default)
        {
            _ = await _dbContext.Accountings.AddAsync(accounting, cancellationToken);
            _ = await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task<DatabaseAccounting> GetAccountingById(string id, CancellationToken cancellationToken = default)
        {
            return _dbContext.Accountings
                .SingleOrDefaultAsync(t => t.Id.ToString() == id, cancellationToken);
        }

        public async Task UpdateAccountingValue(string id, int value, CancellationToken cancellationToken = default)
        {
            DatabaseAccounting accounting = await _dbContext.Accountings.SingleAsync(x => x.Id.ToString() == id, cancellationToken);

            accounting.Value = (int)value;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}