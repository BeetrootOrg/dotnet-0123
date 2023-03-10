namespace HumanResources
{
    public abstract class Employee
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? Title { get; protected init; }
        public string[]? Responsibilities { get; protected init; }
        public int Salary { get; protected init; }
        public TimeOnly WorkingStartTime { get; protected init; }
        public TimeOnly WorkingEndTime { get; protected init; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} has title {Title} with salary {Salary}. \nHis working day start at {WorkingStartTime} and end at {WorkingEndTime}. \nHis responsibility: {string.Join(", ", Responsibilities)}.";
        }
        public abstract Employee ToPromote();
    }
}