using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanceManagement.Domain.Models.Database
{
    [Table("Iterations")]
    public class Iteration
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id {get; set;}

        [Column("money")]
        [Required]
        [MaxLength(255)]
        public int money {get; set;}
    }
}