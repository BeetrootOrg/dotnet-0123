using BatteryMonitorApp.Domain.Models.DataBase;

namespace BatteryMonitorApp.PhysicalDeviceEmulator
{
    public class PhysicalDeviceEmulator
    {
        public static readonly Guid Id = new Guid("DE88CE88-E888-8A88-8888-888888888888");
        public static readonly BatteryData TestBatteryData = new()
        {
            DeviceId = Id,
            Voltage = 12,
            DateTime = new DateTime(2000, 1, 1, 0, 0, 0, 0, 0),
            Status = 0, Current=1, VoltageCharger=0,
        };
    }
}