using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models
{
    [Table("tbl_history")]
    public record History
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("book_id")]
        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }

        [Required]
        [Column("customer_id")]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        [Required]
        [Column("quantity")]
        public int Quantity { get; set; }

        [Required]
        [Column("date")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Required]
        [MaxLength(3)]
        [Column("direction")]
        public string Direction { get; set; }
    }
}