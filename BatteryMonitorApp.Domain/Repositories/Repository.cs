using BatteryMonitorApp.Domain.DbContexts;
using BatteryMonitorApp.Domain.Models.DataBase;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BatteryMonitorApp.Domain.Repositories
{

    public interface IRepository
    {
        Task<int> AddData(BatteryData batteryData, CancellationToken cancellationToken = default);
        Task<BatteryData[]> GetBatteryData(Guid devise, DateTime start, DateTime End, int[] status, CancellationToken cancellationToken = default);
        Task<BatteryRegisteredDevice[]> GetRegisteredDevices(Guid userId, CancellationToken cancellationToken = default);
        Task<int> AddRegisteredDevices(BatteryRegisteredDevice device, CancellationToken cancellationToken = default);
    }

    public class Repository : IRepository
    {
        private readonly ILogger<Repository> _logger;
        private readonly BatteryMonitorContext _dbcontext;
        public Repository(BatteryMonitorContext dbcontext, ILogger<Repository> logger)
        {
            _dbcontext = dbcontext;
            _logger = logger;
        }

        public async Task<int> AddData(BatteryData batteryData, CancellationToken cancellationToken = default)
        {
            try
            {
                _logger.LogDebug($"Repository AddData {batteryData}");
                _ = await _dbcontext.AddAsync(batteryData, cancellationToken);
                var result = await _dbcontext.SaveChangesAsync(cancellationToken);
                _logger.LogInformation($"Repository AddData {batteryData} Resullt={result}");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Repository AddData Error\n{ex}\n BatteryData {batteryData}");
                throw;
            }
        }

        public async Task<int> AddRegisteredDevices(BatteryRegisteredDevice device, CancellationToken cancellationToken = default)
        {
             await _dbcontext.Devices.AddAsync(device, cancellationToken);
            return _dbcontext.SaveChanges();
        }

        public Task<BatteryData[]> GetBatteryData(Guid devise, DateTime start, DateTime end, int[] status, CancellationToken cancellationToken = default)
        {
            try
            {
                _logger.LogDebug($"Repository GetBatteryData for device {devise}");
                var result = _dbcontext.BatteryDatas.Where(x => x.DeviceId == devise).
                    Where(x => x.DateTime >= start && x.DateTime <= end).
                    Where(x => status.Contains(x.Status)).OrderBy(x => x.DateTime).
                    ToArrayAsync(cancellationToken);
                _logger.LogInformation($"Repository GetBatteryData for device {devise}. " +
                    $"Result={string.Join('\n', result)}");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Repository GetBatteryData Error\n{ex}\nDevise " +
                    $"{devise} start {start} end {end}");
                throw;
            }
        }

        public Task<BatteryRegisteredDevice[]> GetRegisteredDevices(Guid userId, CancellationToken cancellationToken = default)
        {
            try
            {
                _logger.LogDebug($"Repository GetBatteryData for user {userId}");
                return _dbcontext.Devices.Where(x => x.UserId == userId).ToArrayAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Repository GetBatteryData for user {userId}\n{ex}");
                throw;
            }
        }
    }
}
