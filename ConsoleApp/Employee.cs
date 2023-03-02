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
        public virtual string? Promotion { get; }
        public virtual string[]? Responsibilities { get; }
        
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
            string currentPosition = this.GetType().ToString().Split('.')[^1]; 
            string responsibilities = Responsibilities == null ? String.Empty : String.Join(", ", Responsibilities); 
            
            return 
                $"Current position: {currentPosition}" +
                $"\nFirst name: {FirstName}; " +
                $"Last name: {LastName}; " + 
                $"Salary: {Salary}; " + 
                $"Start of work: {StartOfWork}; " +
                $"End of work: {EndOfWork}" +
                $"\nPromotion: {Promotion}" + 
                $"\nResponsibilities: {responsibilities}";
        }
    } 
}