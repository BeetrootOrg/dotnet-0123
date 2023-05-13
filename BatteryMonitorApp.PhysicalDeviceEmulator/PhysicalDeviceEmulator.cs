using BatteryMonitorApp.Domain.Models.DataBase;

namespace BatteryMonitorApp.PhysicalDeviceEmulator
{
    public class PhysicalDeviceEmulator
    {
        public double Capacity { get; set; }
        public double NominalVolts { get; set; }
        public double NominalResist { get; set; }

        public double CurrentVolts { get; set; }
        public double CurrentResist { get; set; }
        public double DischargeAmps { get; set; }

        public static readonly Guid Id = new Guid("DE88CE88-E888-8A88-8888-888888888888");
        public static readonly BatteryData TestBatteryData = new()
        {
            DeviceId = Id,
            Voltage = 12,
            DateTime = new DateTime(2000, 1, 1, 0, 0, 0, 0, 0),
            Status = 0, Current=1, VoltageCharger=0,
        };

        public static double GetResisIndex(double capacityindex)
        {
            return (1 / (capacityindex + 0.3));
        }
    }

}