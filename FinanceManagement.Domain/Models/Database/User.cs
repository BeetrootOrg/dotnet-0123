using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanceManagement.Domain.Database
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id {get; set;}

        [Column("email")]
        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email {get; set;}
    }
}