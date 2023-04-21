using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace PersonsSite.Models
{
    [Table("persons")]
    [Index(nameof(Email), IsUnique = true)]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("first_name")]
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Column("last_name")]
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Column("age")]
        [Range(0, 150)]
        public int Age { get; set; }

        [Column("email")]
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}