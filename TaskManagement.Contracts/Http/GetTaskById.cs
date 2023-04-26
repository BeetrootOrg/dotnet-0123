using TaskManagement.Contracts.Models;

namespace TaskManagement.Contracts.Http
{
    public class GetTaskByIdResponse
    {
        public Task Task { get; init; }
    }
}