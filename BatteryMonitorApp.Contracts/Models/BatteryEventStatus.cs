using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatteryMonitorApp.Contracts.Models
{
    public enum BatteryEventStatus
    {
        Default = 0,
        Alarm = 1,
        LoadOfChargeOf = 2,
        LoadOnChargeOf = 3,
        LoadOnChargeOn = 4,
        LoadOfChargeOn = 5
    }
}
