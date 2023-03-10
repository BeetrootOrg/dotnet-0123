namespace ConsoleApp
{
    public class Performer : Employee
    {
        public Performer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = 500;
            Responsibilities = new string[] {"Perform", "Study"};
            Start = new TimeSpan(9,0,0);
            End = new TimeSpan(17, 30, 0);
        }
        public override Manager Promote()
        {
            return new Manager(this.FirstName, this.LastName);
        }
    }
}