namespace Company
{
    public class Performer : Employee
    {
        public Performer(string? firstName, string? lastName, decimal salary, string? startOfWork, string? endOfWork) 
            : base(firstName, lastName, salary, startOfWork, endOfWork)
        {
            _employeeExtra = new PerformerExtra();
        }

        public override Employee Promote(decimal salary, string startOfWork, string endOfWork)
        {
            return new Assistant(FirstName, LastName, salary, startOfWork, endOfWork);
        }
    }
}