namespace ConsoleApp
{
    public class Manager : Employee
    {
        public string Department { get; set; }
        public string PerformanceType { get; set; }

        public override Employee Promote()
        {
            return new Boss
            {
                FirstName = FirstName,
                LastName = LastName,
                Responsibilities = Responsibilities,
                Salary = Salary * 1.5m,
                StartOfWorkday = StartOfWorkday,
                EndOfWorkday = EndOfWorkday,
                Promotion = "Boss",
                Department = Department
            };
        }
    }

   
}

