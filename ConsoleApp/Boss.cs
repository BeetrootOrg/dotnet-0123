namespace Company
{
    public class Boss : Employee
    {
        public override string? Promotion
        { 
            get => _employeeExtra == null ? String.Empty : _employeeExtra.NextPosition();
        }

        public override string[]? Responsibilities
        {
            get => _employeeExtra == null ? new string[0] : _employeeExtra.Responsibilities(); 
        }
        
        public Boss(string? firstName, string? lastName, decimal salary, string? startOfWork, string? endOfWork) 
            : base(firstName, lastName, salary, startOfWork, endOfWork)
        {
            _employeeExtra = new BossExtra();
        }

        public override Employee Promote(decimal salary, string startOfWork, string endOfWork)
        {
            throw new Exception();
        }
    }
}