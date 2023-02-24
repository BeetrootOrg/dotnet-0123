namespace ConsoleApp
{
    public class SoftwareEngineer
    {
        public static readonly SoftwareEngineer Example = new("Jane", "Doe", "jdoe", "jdoe@outlook.com", Positions.CTO, decimal.MaxValue);

        public string FirstName { get; }
        public string LastName { get; }
        public string Username { get; }
        public string Position { get; private set; }
        public decimal Salary { get; private set; }
#pragma warning disable IDE0040
        string Email { get; }
#pragma warning restore IDE0040

        public SoftwareEngineer(string firstName, string lastName, string username, string email,
            string position, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Position = position;
            Salary = salary;
            Email = email;
        }

        public void Promote()
        {
            if (Position == Positions.SoftwareEngineer)
            {
                Position = Positions.SeniorSoftwareEngineer;
                Salary *= 1.5M;
            }
            else if (Position == Positions.SeniorSoftwareEngineer)
            {
                Position = Positions.TechLead;
                Salary *= 2M;
            }
            else if (Position == Positions.TechLead)
            {
                Position = Positions.Architect;
                Salary *= 2.5M;
            }
            else if (Position == Positions.Architect)
            {
                Position = Positions.CTO;
                Salary *= 5M;
            }
        }

        public string GetFullInformation()
        {
            return $"{FirstName} {LastName} ({Username}/{Email}) is a {Position} and makes {Salary:C}";
        }
    }
}