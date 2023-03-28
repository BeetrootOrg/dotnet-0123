namespace ConsoleApp;

public class Assistant : Employee
{
    public string ExecutiveName { get; set; }
    public string Department { get; set; }

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
            Department = Department
        };
    }

}
