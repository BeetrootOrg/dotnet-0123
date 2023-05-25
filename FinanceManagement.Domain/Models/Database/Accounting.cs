using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanceManagement.Domain.Models.Database
{
    public class Accounting
    {
        [Key]
        [Column("id")]
        public Guid Id {get; set;}

        [Column("title")]
        [Required]
        [MaxLength(255)]
        public string Title {get;set;}

        [Column("value")]
        [Required]
        [MaxLength(255)]
        public float Value {get; set;}

        [Column("iterations")]
        public int Iterations {get; set;}

        [Column("created_at")]
        [Required]
        public DateTime CreatedAt {get; set;}

    }
}