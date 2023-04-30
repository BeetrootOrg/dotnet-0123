using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BatteryMonitorApp.Domain.Models.DataBase
{
    [Table("Batteries_Data")]
    public record BatteryData
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [NotNull]
        public Guid DeviceId { get; set; }
        [Required]
        [NotNull]
        public float Voltage { get; set; } = 0;
        [NotNull]
        public float Current { get; set; } = 0;
        [NotNull]
        public float VoltageCharger { get; set; } = 0;
        [NotNull]
        public DateTime DateTime { get; set; } = DateTime.Now;
        [NotNull]
        public int Status { get; set; } = 0;
    }


}
