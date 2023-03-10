namespace ConsoleApp
{
    public class Performer : Employee
    {
        public Performer(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
            Position = "Performer";
            Responsibilities = "Performing all the tasks specified to him";
            Salary = 1000;
            StartOfTheWorkingDay =  new TimeSpan(9, 30, 0);
            EndOfTheWorkingDay = new TimeSpan(18, 0, 0);
        }
        public override string Promotion()
        {
            return "Manager";
        }
        public override Manager Promote()
        {
            return new Manager(this.FirstName, this.LastName);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} is a {Position}, Salary: {Salary}\nResponsibilities: {Responsibilities}\nWork day:{StartOfTheWorkingDay} -- {EndOfTheWorkingDay}";
        }
    }
}