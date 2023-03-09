namespace ConsoleApp
{
    public class Performer : Employee
    {
        public Performer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Responsibility = new string[] { "perform", "doing hard work" };
            Salary = 600;
            StartOfWorkingDay = new TimeSpan(9, 0, 0);
            EndOfWorkingDay = new TimeSpan(18, 0, 0);
        }
        public override string Promotion()
        {
            return "Manager";
        }

        public override Manager Promote()
        {
            return new Manager(this.FirstName, this.LastName);
        }
    }
}