namespace ConsoleApp
{
    public class Assistant : Employee
    {
        public Assistant(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = 3000;
            Responsibilities = new string[] {"Assist", "Teach others", "Help others"};
            Start = new TimeSpan(7,15,0);
            End = new TimeSpan(15, 0, 0);
        }

        public override Boss Promote()
        {
            return new Boss(this.FirstName, this.LastName);
        }
    }
}