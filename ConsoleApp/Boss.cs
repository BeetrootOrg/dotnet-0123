namespace Company
{
    public class Boss : Employee
    {
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