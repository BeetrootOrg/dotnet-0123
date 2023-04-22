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
        [Display(Name = "ID")]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(32)]
        [Column("vendor_code")]
        [Display(Name = "Vendor code")]
        public string VendorCode { get; set; }

        [MaxLength(255)]
        [Column("image")]
        [Display(Name = "Image")]
        public string Image { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("name")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Precision(15, 2)]
        [Column("price")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [MaxLength(1000)]
        [Column("description")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}