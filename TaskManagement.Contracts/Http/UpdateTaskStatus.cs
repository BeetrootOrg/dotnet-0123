using TaskManagement.Contracts.Models;

namespace TaskManagement.Contracts.Http
{
    public class UpdateTaskStatusRequest
    {
        public TaskStatus Status { get; init; }
    }
}