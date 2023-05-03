
namespace BatteryMonitorApp.Contracts.Models.Http
{
    public record BatteryDataShortFormat
    {
        public Guid Di { get; init; }
        public float V { get; init; } = 0;
        public float? C { get; init; } = 0;
        public float? VC { get; init; } = 0;
        public DateTime? Dt { get; init; } = DateTime.Now;
        public int? S { get; init; } = (int)BatteryEventStatus.Default;
    }
}
