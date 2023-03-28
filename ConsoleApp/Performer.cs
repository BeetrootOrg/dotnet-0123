namespace ConsoleApp;

public class Performer : Employee
{
    public string PerformanceType { get; set; }

    public override Employee Promote()
    {
        return new Manager
        {
            FirstName = FirstName,
            LastName = LastName,
            Responsibilities = Responsibilities,
            Salary = Salary * 1.2m,
            StartOfWorkday = StartOfWorkday,
            EndOfWorkday = EndOfWorkday,
            Promotion = "Manager",
            PerformanceType = PerformanceType
        };
    }
}