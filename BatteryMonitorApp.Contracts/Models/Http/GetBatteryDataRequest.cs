using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatteryMonitorApp.Contracts.Models;

namespace BatteryMonitorApp.Contracts.Models.Http
{
    public class GetBatteryDataRequest
    {
        public string DeviceId { get; set; }
        public DateTime? Srart { get; set; }
        public DateTime? End { get; set; }
        public int[]? Status { get; set; }
    }
}
