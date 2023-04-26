using System;

namespace TaskManagement.Contracts.Models
{
    public class Task
    {
        public string Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public TaskStatus Status { get; init; }
        public string AssigneeEmail { get; init; }
    }
}