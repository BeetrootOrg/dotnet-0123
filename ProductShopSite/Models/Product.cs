using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace ProductShopSite.Models
{
    [Table("products")]
    [Index(nameof(VendorCode), IsUnique = true)]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(32)]
        [Column("vendor_code")]
        public string VendorCode { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("name")]
        public string Name { get; set; }
        
        [Precision(15, 2)]
        [Column("price")]
        public decimal Price { get; set; }

        [MaxLength(1000)]
        [Column("description")]
        public string Description { get; set; }
    }
}