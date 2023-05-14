
namespace BatteryMonitorApp.Contracts.Models.Http
{
    public record PhysicalDevice
    {
        public double NominalCapacity { get; set; } = 60;
        public double NominalVolts { get; set; } = 12.7;
        public Guid DeviceId { get; set; }
        public double Current { get; set; } = 5;
        public int delaysecs { get; set; } = 60;
        public DateTime start { get; set; }= DateTime.Now.AddHours(-24);
        public List<NameGuidDevice> Devices { get; set; } = new();
    }

}
