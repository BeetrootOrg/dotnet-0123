namespace ConsoleApp
{
    public class Boss : Employee
    {
        public Boss(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = 6000;
            Responsibilities = new string[] {"Lead", "Be cool", "Appoint salaries"};
            Start = new TimeSpan(7,0,0);
            End = new TimeSpan(18, 30, 0);
        }
        public override Boss Promote()
        {
            throw new ArgumentException("You cannot promote highest position");
        }
    }
}