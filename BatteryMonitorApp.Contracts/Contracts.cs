using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using BatteryMonitorApp.Contracts.Models.Http;
using BatteryMonitorApp.Domain.Models.DataBase;
using BatteryMonitorApp.UnitTests.Repositories;

namespace BatteryMonitorApp.Contracts
{
    public static class BatteryMonitorAppContracts
    {
        public static async Task<bool> AddData(IRepository repo, IMapper mapper,
          BatteryDataShortFormat data, CancellationToken token=default)
        {
            if (data==null) return false;
            var battdata= mapper.Map<BatteryData>(data);
            return (await repo.AddData(battdata))>0;
        }
    }
}
