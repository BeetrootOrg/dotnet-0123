namespace HumanResources
{
    public class Performer : Employee
    {
        string[] _responsibilities = {"resp_21", "resp22", "resp23"};
        int _salary = 1000;   
        string _title = "Performer";
        TimeOnly _workingstart = new TimeOnly (08,00,00);
        TimeOnly _workingend = new TimeOnly (18,00,00);
        
        public Performer (string _firstName, string _lastName)
        {
            FirstName = _firstName;
            LastName = _lastName;
            Title = _title;
            Responsibilities = _responsibilities;
            Salary = _salary;
            WorkingStartTime = _workingstart;
            WorkingEndTime = _workingend;
        }
        public override Employee ToPromote() => new Manager(this.FirstName, this.LastName);
    }
}