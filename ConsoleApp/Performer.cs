namespace Company
{
    public class Performer : Employee
    {
        public override string? Promotion
        { 
            get => _employeeExtra == null ? String.Empty : _employeeExtra.Promotion();
        }

        public override string[]? Responsibilities
        {
            get => _employeeExtra == null ? new string[0] : _employeeExtra.Responsibilities(); 
        }
        
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