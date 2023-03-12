namespace ConsoleApp
{
    public abstract class Employee
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        protected string[]? Responsibilities { get; init; }
        protected decimal Salary { get; init; }
        protected TimeOnly Start { get; init; }
        protected TimeOnly End { get; init; }

        public Employee(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException("First name or last name should not be null or empty.");
            }

            FirstName = firstName;
            LastName = lastName;
        }
        public Type Promotion()
        {
            return this is Assistant
                ? typeof(Manager) : this is Manager
                ? typeof(Performer) : this is Performer
                ? typeof(Boss) : this is Boss
                ? typeof(Boss) : typeof(Boss);
        }
        public abstract Employee Promote();
    }
}