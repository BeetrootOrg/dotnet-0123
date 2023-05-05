using AutoMapper;
using BatteryMonitorApp.Contracts.Models.Http;
using BatteryMonitorApp.Domain.Models.DataBase;
using BatteryMonitorApp.Domain.Repositories;

namespace BatteryMonitorApp.Contracts
{
    public static class BatteryMonitorAppContracts
    {
        public static async Task<bool> AddData(IRepository repo, IMapper mapper,
          BatteryDataShortFormat data, CancellationToken token=default)
        {
            if (data==null) return false;
            var battdata= mapper.Map<BatteryData>(data);
            return (await repo.AddData(battdata, token))>0;
        }
    }
}
