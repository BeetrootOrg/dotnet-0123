using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models
{
    [Table("tbl_customers")]
    public record Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("first_name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("last_name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [MaxLength(1000)]
        [Column("address")]
        public string Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}