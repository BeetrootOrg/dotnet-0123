namespace ConsoleApp
{
    public class Boss : Employee
    {
        public Boss(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
            Position = "Boss";
            Responsibilities = "Control of work";
            Salary = 4000;
            StartOfTheWorkingDay =  new TimeSpan(9, 30, 0);
            EndOfTheWorkingDay = new TimeSpan(18, 0, 0);
        }
        public override string Promotion()
        {
            return "Max Position";
        }
        public override Boss Promote()
        {
            throw new ArgumentException("Max position, you can't to promote");
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} is a {Position}, Salary: {Salary}\nResponsibilities: {Responsibilities}\nWork day:{StartOfTheWorkingDay} -- {EndOfTheWorkingDay}";
        }
    }
}