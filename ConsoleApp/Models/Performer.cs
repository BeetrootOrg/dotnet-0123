namespace ConsoleApp.Models
{
    public class Performer:Employee
    { 
        public Performer(string firstName, string lastName) :base(firstName, lastName)
        {
            Position=Positions.Performer;
        }
    }
}