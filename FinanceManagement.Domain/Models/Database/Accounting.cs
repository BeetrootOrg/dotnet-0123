using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanceManagement.Domain.Database
{
    public class Accounting
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [Required]
        public long[] Iterations {get; set;}

        [Column("created_at")]
        [Required]
        public TimeSpan Created_at {get; set;}

        [Column("assignee_id")]
        public long AssigneeId {get;set;}

        [ForeignKey(nameof(AssigneeId))]
        public virtual User Assignee {get;set;}
    }
}