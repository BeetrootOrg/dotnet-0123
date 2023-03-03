namespace ConsoleApp.Models
{
    public abstract class Employee
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        private Employee()
        {
            throw new Exception("The name of the employee must be passed to the parameters of the class constructor");
        }

        public Employee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}