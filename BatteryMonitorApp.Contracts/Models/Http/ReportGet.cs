

namespace BatteryMonitorApp.Contracts.Models.Http
{
    public record ReportGet
    {
        public Guid DeviceId { get; set; }
        public DateTime From { get; set; }= DateTime.Now;
        public DateTime T { get; set; } = DateTime.Now.AddDays(-7);
        public List<NameGuidDevice> Devices { get; set; } = new();
    }
}
