using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public record Histiry
    {
        [Key]
        public int Id {get;set;}
        [Required]
        public virtual int BookId {get;set;}
        public virtual Book Book {get;set;}
        [Required]
        public virtual int CustomerId {get;set;}
        public virtual Customer Customer {get;set;}
        [Required]
        public DateTime Taken {get;set;}=DateTime.UtcNow;
        public DateTime? Returned {get;set;}=null;
    }
}