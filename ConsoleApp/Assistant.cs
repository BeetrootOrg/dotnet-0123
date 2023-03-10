namespace HumanResources
{
    public class Assistant : Employee
    {
        string[] _responsibilities = {"resp_11", "resp12", "resp13"};
        int _salary = 500;
        string _title = "Assistant";   
        TimeOnly _workingstart = new TimeOnly (08,00,00);
        TimeOnly _workingend = new TimeOnly (19,00,00);
        
        public Assistant (string _firstName, string _lastName)
        {
            FirstName = _firstName;
            LastName = _lastName;
            Title = _title;
            Responsibilities = _responsibilities;
            Salary = _salary;
            WorkingStartTime = _workingstart;
            WorkingEndTime = _workingend;
        }
        public override Employee ToPromote() => new Performer(this.FirstName, this.LastName);
    }

}