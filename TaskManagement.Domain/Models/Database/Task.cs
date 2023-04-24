using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagement.Domain.Models.Database
{
    [Table("tasks")]
    public class Task
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("title")]
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Column("description")]
        [Required]
        public string Description { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("status")]
        public int Status { get; set; }

        [Column("assignee_id")]
        public long? AssigneeId { get; set; }

        [ForeignKey(nameof(AssigneeId))]
        public virtual User Assignee { get; set; }
    }
}