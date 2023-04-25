using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebApp.Models
{
    public class Category
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
        public virtual int GoodImageId { get; set; }
        public virtual GoodImage Image { get; set; }
        [Required]
        public DateTime CreateDateTime { get; set; } = DateTime.UtcNow;
        
        public List<Good> Goods { get; set; } 

    }
}
