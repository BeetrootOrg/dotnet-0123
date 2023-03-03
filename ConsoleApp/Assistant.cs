namespace Company
{
    public class Assistant : Employee
    {
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