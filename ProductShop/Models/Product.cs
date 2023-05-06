using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductShop.Models
{
    [Table("product_shop")]
    [Index(nameof(Email), IsUnique = true)]
    public class Product
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Column("name")]
        [Display(Name = "Name")]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [Column("price", TypeName = "money")]
        [Display(Name = "Price")]
        [Required]
        public decimal Price { get; set; }
        [Column("quantity")]
        [Display(Name = "Quantity")]
        [Range(0, int.MaxValue)]
        [Required]
        public int Quantity { get; set; }
        [Column("description")]
        [Display(Name = "Description")]
        [MaxLength(500)]
        public string Description { get; set; }
        [Column("category")]
        [Display(Name = "Category")]
        [MaxLength(50)]
        [Required]
        public string Category { get; set; }
        [Column("email")]
        [EmailAddress]
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}