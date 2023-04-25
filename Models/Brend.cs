using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebApp.Models
{
    public class Brend
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        [NotNull]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(1000)]
        [NotNull]
        public string Description { get; set; } = string.Empty;
        public virtual List<Good> Goods { get; set; }
        [NotNull]
        public DateTime CreateDateTime { get; set; } = DateTime.UtcNow;
    }
}
