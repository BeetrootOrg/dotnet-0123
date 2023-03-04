namespace ConsoleApp.Models
{
    public class Manager:Employee
    { 
        public Manager(string firstName, string lastName) :base(firstName, lastName)
        {
            Position=Positions.Manager;
        }
    }
}