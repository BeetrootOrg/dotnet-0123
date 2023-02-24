namespace ConsoleApp
{
    public class Employee
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Username { get; }
        public string Position { get; private set; }
        public decimal Salary { get; private set; }

        public Employee(string firstName, string lastName, string username,
            string position, decimal salary)
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

        public string GetFullInformation()
        {
            return $"{FirstName} {LastName} ({Username}) is a {Position} and makes {Salary:C}";
        }
    }
}