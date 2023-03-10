namespace ConsoleApp
{
    public class Manager : Employee
    {
        public Manager(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
            Position = "Manager";
            Responsibilities = new string[] {};
            Salary = 2000;
            StartOfTheWorkingDay =  new TimeSpan(9, 30, 0);
            EndOfTheWorkingDay = new TimeSpan(18, 0, 0);
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