namespace HumanResources
{
    public class Boss : Employee
    {
        string[] _responsibilities = {"do nothing 1", "do nothing 2", "do nothing 3"};
        int _salary = 5000; 
        string _title = "Boss";  
        TimeOnly _workingstart = new TimeOnly (12,00,00);
        TimeOnly _workingend = new TimeOnly (13,00,00);
        
        public Boss (string _firstName, string _lastName)
        {
            FirstName = _firstName;
            LastName = _lastName;
            Title = _title;
            Responsibilities = _responsibilities;
            Salary = _salary;
            WorkingStartTime = _workingstart;
            WorkingEndTime = _workingend;
        }
        public override Employee ToPromote() => throw new ArgumentException("This is a big boss, there's nowhere to promote ");
    }
}