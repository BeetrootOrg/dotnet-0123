using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatteryMonitorApp.Domain.DbContexts;
using BatteryMonitorApp.Domain.Models.DataBase;

namespace BatteryMonitorApp.UnitTests.Repositories
{
    public interface IRepository
    {
        Task AddData(BatteryData batteryData, CancellationToken cancellationToken = default);
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
    }
}
