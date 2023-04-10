using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models
{
    [Table("tbl_products")]
    public record Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("name")]
        public string Name { get; set; }

        [Column("money", TypeName = "money")]
        public decimal Money { get; set; }

        [Required]
        [Column("description")]
        public string Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}