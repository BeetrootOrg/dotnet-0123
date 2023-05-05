using BatteryMonitorApp.Domain.Models.DataBase;

namespace BatteryMonitorApp.Contracts.Models.Http
{
    public class BatteryDataView
    {
        public float V { get; private set; } = 0;
        public float? C { get; private set; } = 0;
        public float? VC { get; private set; } = 0;
        public DateTime? DT { get; private set; } = DateTime.UtcNow;
        public BatteryEventStatus? S { get; private set; } = BatteryEventStatus.Default;
        public static BatteryDataView FromBatteryData(BatteryData data)
        {
            return new()
            {
                C = data.Current,
                V = data.VoltageCharger,
                VC = data.VoltageCharger,
                DT = data.DateTime,
                S = (BatteryEventStatus)data.Status
            };
        }
    }
}
