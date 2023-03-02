namespace Company
{
    public class Assistant : Employee
    {
        public override string? Promotion
        { 
            get => _employeeExtra == null ? String.Empty : _employeeExtra.Promotion();
        }

        public override string[]? Responsibilities
        {
            get => _employeeExtra == null ? new string[0] : _employeeExtra.Responsibilities(); 
        }
        
        public Assistant(string? firstName, string? lastName, decimal salary, string? startOfWork, string? endOfWork) 
            : base(firstName, lastName, salary, startOfWork, endOfWork)
        {
            _employeeExtra = new AssistantExtra();
        }

        public override Employee Promote(decimal salary, string startOfWork, string endOfWork)
        {
            return new Manager(FirstName, LastName, salary, startOfWork, endOfWork);
        }
    }
}