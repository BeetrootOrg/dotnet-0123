namespace ConsoleApp
{
    public class Manager : Employee
    {
        public Manager(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = 1500;
            Responsibilities = new string[] {"Manage tasks", "Help others"};
            Start = new TimeSpan(8,0,0);
            End = new TimeSpan(15, 0, 0);
        }
        
        public override Assistant Promote()
        {
            return new Assistant(this.FirstName, this.LastName);
        }
    }
}