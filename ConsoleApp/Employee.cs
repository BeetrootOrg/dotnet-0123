namespace ConsoleApp
{
    public abstract class Employee
    {
        public string FirstName {get; init;}
        public string LastName {get; init;}
        public string Position {get; init;}
        public string Responsibilities {get; init;}
        public decimal Salary {get; init;}
        public TimeSpan StartOfTheWorkingDay {get; init;}
        public TimeSpan EndOfTheWorkingDay {get; init;}
        public abstract string Promotion();
        public abstract Employee Promote(); 
        
        public void GetFullInformation()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} is a {Position}, Salary: {Salary}\nResponsibilities: {Responsibilities}\nWork day:{StartOfTheWorkingDay} -- {EndOfTheWorkingDay}";
        }
    }
}