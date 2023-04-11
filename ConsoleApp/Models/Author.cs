using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models
{
    [Table("tbl_authors")]
    public record Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("first_name")]
        public string FirstName { get; set; }

        [MaxLength(255)]
        [Column("last_name")]
        public string LastName { get; set; } 

        public virtual ICollection<Book> Books { get; set; }
    }
}