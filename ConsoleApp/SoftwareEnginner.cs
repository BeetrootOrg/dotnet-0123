namespace ConsoleApp
{
    public class SoftwareEnginner
    {
        public static readonly SoftwareEnginner Example = new SoftwareEnginner("Jane", "Doe", "jdoe", "jdoe@gmail.com", Positions.CTO, decimal.MaxValue);
        public string FirstName {get;}
        public string LastName {get;}
        public string Username {get;}
        public string Position {get; private set;}
        public decimal Salary {get; private set;}
        string Email {get; set;}

        public SoftwareEnginner(string firtsName, string lastName, string username, string email, string position, decimal salary)
        {
            FirstName = firtsName;
            LastName = lastName;
            Username = username;
            Position = position;
            Salary = salary;
        }

        public void Promote()
        {
             if (Position == Positions.SoftwareEnginner)
             {
                Position = Positions.SeniorSoftwareEnginner;
                Salary *= 1.5M;
             }
             else if (Position == Positions.SeniorSoftwareEnginner)
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