namespace ConsoleApp.Models
{
    public abstract class Employee
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public Positions Position { get; init; }
        public Days StartWorkingDay { get=>Career.GetStartWorkingDay(Position); }
        public Days EndWorkingDay { get=>Career.GetEndWorkingDay (Position); }
        public double Salary { get=>Career.GetSalary(Position); }
        public Responsibilities[] Responsibilities { get=>Career.GetResponsibilities (Position); }
        public Positions Promotion { get=>Career.GetPromotion(Position); }
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