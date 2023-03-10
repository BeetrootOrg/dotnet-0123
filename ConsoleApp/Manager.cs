namespace HumanResources
{
    public class Manager : Employee
    {
        string[] _responsibilities = {"resp_31", "resp32", "resp33"};
        int _salary = 1500;   
        string _title = "Manager";
        TimeOnly _workingstart = new TimeOnly (09,00,00);
        TimeOnly _workingend = new TimeOnly (18,00,00);
        
        public Manager (string _firstName, string _lastName)
        {
            FirstName = _firstName;
            LastName = _lastName;
            Title = _title;
            Responsibilities = _responsibilities;
            Salary = _salary;
            WorkingStartTime = _workingstart;
            WorkingEndTime = _workingend;
        }
        public override Employee ToPromote() => new Boss(this.FirstName, this.LastName);
    }
}