using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using BatteryMonitorApp.Domain.Models.DataBase;

namespace BatteryMonitorApp.Contracts.Models.Http
{
    public record BatteryDevice
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(255)]
        [NotNull]
        public string DeviceName { get; set; } = string.Empty;
        [MaxLength(100)]
        [NotNull]
        public string DeviceDescription { get; set; } = string.Empty;
        public BatteryDevice() { }
        public BatteryDevice(BatteryRegisteredDevice device){
            Id = device.Id;
            DeviceName = device.DeviceName;
            DeviceDescription = device.DeviceDescription;
        }
    }
}
