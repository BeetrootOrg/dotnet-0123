using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatteryMonitorApp.Contracts.Models
{
    public class BatteryDataGet
    {
        public float Voltage { get; init; } = 0;
        public float Current { get; init; } = 0;
        public float VoltageCharger { get; init; } = 0;
        public DateTime DateTime { get; init; } = DateTime.UtcNow;
        public BatteryEventStatus Status { get; init; } = BatteryEventStatus.Default;
    }
}
