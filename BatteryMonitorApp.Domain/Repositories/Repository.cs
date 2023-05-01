using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatteryMonitorApp.Domain.DbContexts;
using BatteryMonitorApp.Domain.Models.DataBase;

using Microsoft.EntityFrameworkCore;

namespace BatteryMonitorApp.UnitTests.Repositories
{
    public interface IRepository
    {
        Task AddData(BatteryData batteryData, CancellationToken cancellationToken = default);
        Task <BatteryData[]> GetBatteryData(Guid devise, DateTime start, DateTime End, int[] status, CancellationToken cancellationToken = default);
    }

    public class Repository : IRepository
    {
        private readonly BatteryMonitorContext _dbcontext;
        public Repository(BatteryMonitorContext dbcontext)
        { _dbcontext = dbcontext; }

        public async Task AddData(BatteryData batteryData, CancellationToken cancellationToken = default)
        {
            _ = await _dbcontext.AddAsync(batteryData, cancellationToken);
            _ = await _dbcontext.SaveChangesAsync(cancellationToken);
        }

        public Task<BatteryData[]> GetBatteryData(Guid devise, DateTime start, DateTime end, int[] status, CancellationToken cancellationToken = default)
        {
            return _dbcontext.BatteryDatas.Where(x => x.DateTime >= start && x.DateTime <= end).
                Where(x => status.Contains(x.Status)).OrderBy(x => x.DateTime).ToArrayAsync(cancellationToken); 
        }
    }
}
