namespace ConsoleApp
{
    public class Boss : Employee
    {
        public Boss(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Responsibility = new string[] { "leading team to better future", "pretending doing hard work" };
            Salary = 3000;
            StartOfWorkingDay = new TimeSpan(9, 0, 0);
            EndOfWorkingDay = new TimeSpan(15, 0, 0);
        }
        public override string Promotion()
        {
            return "Person is on top";
        }

        public override Boss Promote()
        {
            throw new ArgumentException("You cannot promote highest position");
        }
    }
}