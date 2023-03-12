namespace ConsoleApp
{
    public class Manager : Employee
    {
        public Manager(string firstName, string lastName) : base(firstName, lastName)
        {
            Responsibilities = new string[] { "Managing projects", "Supervising employees" };
            Salary = 1600;
            Start = new TimeOnly(9, 30);
            End = new TimeOnly(17, 40);

        }
        public override Employee Promote() => new Performer(FirstName, LastName);
    }
}