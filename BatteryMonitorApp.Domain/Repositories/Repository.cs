using BatteryMonitorApp.Domain.DbContexts;
using BatteryMonitorApp.Domain.Models.DataBase;

using Microsoft.EntityFrameworkCore;

namespace BatteryMonitorApp.Domain.Repositories
{

    public interface IRepository
    {
        Task<int> AddData(BatteryData batteryData, CancellationToken cancellationToken = default);
        Task<BatteryData[]> GetBatteryData(Guid devise, DateTime start, DateTime End, int[] status, CancellationToken cancellationToken = default);
    }

    public class Repository : IRepository
    {
        private readonly BatteryMonitorContext _dbcontext;
        public Repository(BatteryMonitorContext dbcontext)
        { _dbcontext = dbcontext; }

        public async Task<int> AddData(BatteryData batteryData, CancellationToken cancellationToken = default)
        {
            _ = await _dbcontext.AddAsync(batteryData, cancellationToken);
            return await _dbcontext.SaveChangesAsync(cancellationToken);
        }

        public Task<BatteryData[]> GetBatteryData(Guid devise, DateTime start, DateTime end, int[] status, CancellationToken cancellationToken = default)
        {
            return _dbcontext.BatteryDatas.Where(x=>x.DeviceId==devise).
                Where(x => x.DateTime >= start && x.DateTime <= end).
                Where(x => status.Contains(x.Status)).OrderBy(x => x.DateTime).ToArrayAsync(cancellationToken); 
        }
    }
}
