namespace ConsoleApp
{
    public class Employee
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Username { get; init; }
        public string Position { get;private set; }
        public decimal Salary { get;private set; }

        public Employee(string firstName, string lastName, string username, string position, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Position = position;
            Salary = salary;
        }

        public void Promote()
        {
            if (Position == Positions.SoftwareEngineer)
            {
                Position = Positions.SeniorSoftwareEngineer;
                Salary *= 1.5M;
            }
        }
    }
}