using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodFetch.Domain.Database.Models
{
    [Table("tbl_products")]
    public class Product
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("title")]
        [MaxLength(100)]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("calories")]
        [Range(0, int.MaxValue)]
        public int Calories { get; set; }
        [Column("restaurant_id")]
        public int RestaurantId { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}