namespace ConsoleApp
{
    public class Assistant : Employee
    {
        public Assistant(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
            Position = "Assistant";
            Responsibilities = "Help to Performer";
            Salary = 500;
            StartOfTheWorkingDay =  new TimeSpan(9, 30, 0);
            EndOfTheWorkingDay = new TimeSpan(15, 0, 0);
        }
        public override string Promotion()
        {
            return "Performer";
        }
        public override Performer Promote()
        {
            return new Performer(this.FirstName, this.LastName);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} is a {Position}, Salary: {Salary}\nResponsibilities: {Responsibilities}\nWork day:{StartOfTheWorkingDay} -- {EndOfTheWorkingDay}";
        }
    }
}