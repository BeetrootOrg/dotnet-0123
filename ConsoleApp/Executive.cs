namespace ConsoleApp;

public class Executive : Employee
{
    public string Department { get; set; }
    
    public string Company { get; set; }

    public override Employee Promote()
    {
        throw new NotImplementedException();
    }
}
