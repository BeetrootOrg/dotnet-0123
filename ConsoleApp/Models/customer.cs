using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public record Customer
    {
        [Key]
        public int Id {get;set;}
        [MaxLength(150)]
        public string? FirstName {get;set;}
        [MaxLength(150)]
        public string? LastName {get;set;}
        public List<Histiry> Histiries {get;set;}=new();
    }
}