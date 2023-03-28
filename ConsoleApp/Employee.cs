namespace ConsoleApp
{
    public abstract class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] Responsibilities { get; set; }
        public decimal Salary { get; set; }
        public TimeSpan StartOfWorkday { get; set; }
        public TimeSpan EndOfWorkday { get; set; }
        public string Promotion { get; set; }

        public virtual Employee Promote()
        {
            throw new NotImplementedException();
        }
    }
}
