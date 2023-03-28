namespace ConsoleApp;

public class Boss : Employee
{
    public string Department { get; set; }

    public override Employee Promote()
    {
        return new Executive
        {
            FirstName = FirstName,
            LastName = LastName,
            Responsibilities = Responsibilities,
            Salary = Salary * 2m,
            StartOfWorkday = StartOfWorkday,
            EndOfWorkday = EndOfWorkday,
            Promotion = "CEO",
            Department = Department
        };
    }
}