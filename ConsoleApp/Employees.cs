namespace ConsoleApp
{
    public interface IEmployee
    {
        string FirstName { get; }
        string LastName { get; }
        string[] Responsibilities { get; }
        decimal Salary { get; }
        TimeOnly StartOfWork { get; }
        TimeOnly EndOfWork { get; }
        string Promotion();
        IEmployee Promote();
    }

    public class Performer : IEmployee
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string[] Responsibilities => new[] { "Performing" };
        public decimal Salary => 1000;
        public TimeOnly StartOfWork => new(9, 0, 0);
        public TimeOnly EndOfWork => new(18, 0, 0);

        public string Promotion()
        {
            return nameof(Assistant);
        }

        public IEmployee Promote()
        {
            return new Assistant
            {
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }

    public class Assistant : IEmployee
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string[] Responsibilities => new[] { "Performing", "Assisting" };
        public decimal Salary => 2000;
        public TimeOnly StartOfWork => new(9, 0, 0);
        public TimeOnly EndOfWork => new(18, 0, 0);

        public string Promotion()
        {
            return nameof(Manager);
        }

        public IEmployee Promote()
        {
            return new Manager
            {
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }

    public class Manager : IEmployee
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string[] Responsibilities => new[] { "Performing", "Assisting", "Managing" };
        public decimal Salary => 3000;
        public TimeOnly StartOfWork => new(9, 0, 0);
        public TimeOnly EndOfWork => new(17, 0, 0);

        public string Promotion()
        {
            return nameof(Boss);
        }

        public IEmployee Promote()
        {
            return new Boss
            {
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }

    public class Boss : IEmployee
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string[] Responsibilities => new[] { "Performing", "Assisting", "Managing", "Bossing" };
        public decimal Salary => 4000;
        public TimeOnly StartOfWork => new(9, 0, 0);
        public TimeOnly EndOfWork => new(16, 0, 0);

        public string Promotion()
        {
            return "Fuck you";
        }

        public IEmployee Promote()
        {
            throw new ArgumentException("You can't promote a boss");
        }
    }
}