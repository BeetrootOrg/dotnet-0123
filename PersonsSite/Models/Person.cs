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
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Column("first_name")]
        [Required]
        [MaxLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        [Required]
        [MaxLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Column("age")]
        [Range(0, 150)]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Column("email")]
        [EmailAddress]
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}