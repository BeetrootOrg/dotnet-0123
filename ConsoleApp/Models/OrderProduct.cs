using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models
{
    [Table("tbl_orders_products")]
    public record OrderProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("order_id")]
        public int OrderId { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
    }
}