namespace ConsoleApp
{
    public class Boss : Employee
    {
        public Boss(string firstName, string lastName) : base(firstName, lastName)
        {
            Responsibilities = new string[] { "Running the company" };
            Salary = 42000;
            Start = new TimeOnly(12, 30);
            End = new TimeOnly(16, 45);
        }
        public override Employee Promote() => throw new InvalidOperationException("Do you wanna make him be God?");
    }
}