using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace Marketplace.Models
{
    [Table("products")]
    [Index(nameof(Name), IsUnique = true)]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Column("price")]
        [Required]
        public decimal Price { get; set; }
        [Column("description")]
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        [Column("is_available")]
        [Required]
        public bool IsAvailable { get; set; }
    }
}