using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatteryMonitorApp.Contracts.Models;

namespace BatteryMonitorApp.Contracts.Http
{
    public class GetBatteryDataResponse
    {
        public IEnumerable<BatteryDataGet> Datas { get; init; }
    }
}
