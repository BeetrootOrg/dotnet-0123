namespace ConsoleApp
{
    public class Assistant : Employee
    {
        public Assistant(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Responsibility = new string[] { "assist to performer", "doing light work" };
            Salary = 300;
            StartOfWorkingDay = new TimeSpan(9, 0, 0);
            EndOfWorkingDay = new TimeSpan(18, 0, 0);
        }
        public override string Promotion()
        {
            return "Performer";
        }

        public override Performer Promote()
        {
            return new Performer(this.FirstName, this.LastName);
        }
    }
}