namespace ConsoleApp
{
    public class Manager : Employee
    {
        public Manager(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Responsibility = new string[] { "manage work of assistant and performer", "work with problem clients" };
            Salary = 900;
            StartOfWorkingDay = new TimeSpan(9, 0, 0);
            EndOfWorkingDay = new TimeSpan(16, 0, 0);
        }
        public override string Promotion()
        {
            return "Boss";
        }

        public override Boss Promote()
        {
            return new Boss(this.FirstName, this.LastName);
        }
    }
}