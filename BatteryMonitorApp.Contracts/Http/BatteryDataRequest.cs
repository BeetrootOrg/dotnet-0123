using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatteryMonitorApp.Contracts.Models;

namespace BatteryMonitorApp.Contracts.Http
{
    public class BatteryDataRequest
    {
        public Guid DeviceId { get; init; }
        public float Voltage { get; init; } = 0;
        public float Current { get; init; } = 0;
        public float VoltageCharger { get; init; } = 0;
        public DateTime DateTime { get; init; } = DateTime.Now;
        public BatteryEventStatus Status { get; init; } = BatteryEventStatus.Default;
    }
}
