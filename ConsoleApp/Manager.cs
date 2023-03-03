namespace Company
{
    public class Manager : Employee
    {
        public override string? Promotion
        { 
            get => _employeeExtra == null ? String.Empty : _employeeExtra.Promotion();
        }

        public override string[]? Responsibilities
        {
            get => _employeeExtra == null ? new string[0] : _employeeExtra.Responsibilities(); 
        }
        
        public Manager(string? firstName, string? lastName, decimal salary, string? startOfWork, string? endOfWork) 
            : base(firstName, lastName, salary, startOfWork, endOfWork)
        {
            _employeeExtra = new ManagerExtra();
        }

        public override Employee Promote(decimal salary, string startOfWork, string endOfWork)
        {
            return new Boss(FirstName, LastName, salary, startOfWork, endOfWork);
        }
    }
}