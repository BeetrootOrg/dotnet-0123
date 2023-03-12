namespace ConsoleApp
{
    public class Assistant : Employee
    {
        public Assistant(string firstName, string lastName) : base(firstName, lastName)
        {
            Responsibilities = new string[] { "Assisting managers" };
            Salary = 1000;
            Start = new TimeOnly(8, 30);
            End = new TimeOnly(16, 20);

        }
        public override Employee Promote() => new Manager(FirstName, LastName);
    }
}