using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebApp.Models
{
    public record Good
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
        [Required]
        public int Stock { get; set; } = 1;
        public decimal Price { get; set; } = 1;
        public virtual int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual int BrendId { get; set; }
        public virtual Brend? Brend { get; set; }
        public virtual int GoodImageId{  get; set; }
        public virtual GoodImage GoodImage { get; set; } = new();
        [NotNull]
        public DateTime CreateDateTime { get; set; } = DateTime.UtcNow;
    }
}
