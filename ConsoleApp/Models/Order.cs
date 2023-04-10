using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models
{
    [Table("tbl_orders")]
    public record Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("order_date_time")]
        public DateTime OrderDateTime { get; set; }

        [Column("customer_id")]
        public int? CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}