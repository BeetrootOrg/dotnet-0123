namespace ConsoleApp
{
    public class Performer : Employee
    {
        public Performer(string firstName, string lastName) : base(firstName, lastName)
        {
            Responsibilities = new string[] { "Performing tasks assigned by managers" };
            Salary = 3000;
            Start = new TimeOnly(10, 30);
            End = new TimeOnly(15, 00);

        }
        public override Employee Promote() => new Boss(FirstName, LastName);
    }
}