namespace ConsoleApp
{
    public abstract class Employee
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string[] Responsibility { get; init; }
        public decimal Salary { get; init; }
        public TimeSpan StartOfWorkingDay { get; init; }
        public TimeSpan EndOfWorkingDay { get; init; }
        public abstract string Promotion();
        public abstract Employee Promote();
        public override string ToString()
        {
            return $"FirstName: {FirstName}\n LastName: {LastName}\n Salary: {Salary}\n" +
                                $" StartOfWorkingDay: {StartOfWorkingDay}\n EndOfWorkingDay: {EndOfWorkingDay}\n" +
                                "Responsibility: " + String.Join(", ", Responsibility);
        }
    }
}