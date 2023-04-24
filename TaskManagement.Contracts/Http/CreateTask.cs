namespace TaskManagement.Contracts.Http
{
    public class CreateTaskRequest
    {
        public string Title { get; init; }
        public string Description { get; init; }
    }

    public class CreateTaskResponse
    {
        public string Id { get; init; }
    }
}