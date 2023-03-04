namespace ConsoleApp.Models
{
    public class Assistant:Employee
    { 
        public Assistant(string firstName, string lastName) :base(firstName, lastName)
        {
            Position=Positions.Assistant;
        }
    }
}