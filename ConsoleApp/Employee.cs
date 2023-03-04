using System.Text;

namespace Company
{
    public abstract class Employee
    {
        protected IEmployeeExtra? _employeeExtra;
        public string? FirstName { get; init; } 
        public string? LastName { get; init; } 
        public decimal Salary { get; init; } 
        public string? StartOfWork { get; init; }
        public string? EndOfWork { get; init; }
        
        public string? Promotion
        { 
            get => _employeeExtra == null ? String.Empty : _employeeExtra.Promotion();
        }
        
        public string[]? Responsibilities
        {
            get => _employeeExtra == null ? new string[0] : _employeeExtra.Responsibilities(); 
        }
        
        public Employee(string? firstName, string? lastName, decimal salary, string? startOfWork, string? endOfWork)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            StartOfWork = startOfWork;
            EndOfWork = endOfWork;
        }

        public abstract Employee Promote(decimal salary, string startOfWork, string endOfWork);

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            stringBuilder.Append($"Current position: {GetCurrentPosition()}; ");
            stringBuilder.Append($"First name: {FirstName}; ");
            stringBuilder.Append($"Last name: {LastName}; ");
            stringBuilder.Append($"Salary: {Salary}; ");
            stringBuilder.Append($"Start of work: {StartOfWork}; ");
            stringBuilder.Append($"End of work: {EndOfWork}; ");
            stringBuilder.Append($"Promotion: {Promotion}; ");
            stringBuilder.Append($"Responsibilities: {GetResponsibilities()}");

            return stringBuilder.ToString();
        }

        private string GetCurrentPosition() => this.GetType().ToString().Split('.')[^1];
        private string GetResponsibilities() => Responsibilities == null ? String.Empty : String.Join(", ", Responsibilities);
 
    } 
}