namespace ConsoleApp.Models
{
    public  class Employee : SealClass
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public override sealed Positions Position { get; init; }
        public override sealed Days StartWorkingDay { get => Career.GetStartWorkingDay(Position); }
        public override sealed Days EndWorkingDay { get => Career.GetEndWorkingDay(Position); }
        public override sealed double Salary { get => Career.GetSalary(Position); }
        public override sealed Responsibilities[] Responsibilities { get => Career.GetResponsibilities(Position); }
        public override sealed Positions Promotion { get => Career.GetPromotion(Position); }
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

    public abstract class SealClass
    {
        public abstract Positions Position { get; init; }
        public abstract Days StartWorkingDay { get; }
        public abstract Days EndWorkingDay { get; }
        public abstract double Salary { get; }
        public abstract Responsibilities[] Responsibilities { get; }
        public abstract Positions Promotion { get; }
    }
}