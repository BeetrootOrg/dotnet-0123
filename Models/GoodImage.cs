using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebApp.Models
{
    public class GoodImage
    {
        [Key]
        public int Id { get; set; }
        [NotNull]
        public string Path { get; set; } = string.Empty;
        [NotNull]
        public DateTime CreateDateTime { get; set; } = DateTime.UtcNow;
    }
}
