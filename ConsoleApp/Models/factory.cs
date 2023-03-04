namespace ConsoleApp.Models
{
    public enum Positions
    {
        Assistant = 0,
        Performer = 1,
        Manager = 2,
        Boss = 3
    }

    public enum Days
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7,
        Unknown = -1,
    }

    public enum Responsibilities
    {
        cleaning = 0,
        coffee = 1,
        sending = 2,
        letters = 3,
        work_overtime = 4,
        make_mistakes = 5,
        write_code = 6,
        meetings = 7,
        payments = 8,
        tasks = 9,
        behold = 10,
        Promote=11
    }

    public static class Career
    {
        
        public static Days GetStartWorkingDay(Positions position)
        {
            return position switch
            {
                Positions.Assistant => Days.Tuesday,
                Positions.Performer => Days.Monday,
                Positions.Manager => Days.Thursday,
                Positions.Boss => Days.Sunday,
                _ => throw new Exception("Unknown day of the week"),
            };
        }
        public static Days GetEndWorkingDay(Positions position)
        {
            return position switch
            {
                Positions.Assistant => Days.Friday,
                Positions.Performer => Days.Saturday,
                Positions.Manager => Days.Friday,
                Positions.Boss => Days.Sunday,
                _ => throw new Exception("Unknown day of the week"),
            };
        }

        public static double GetSalary(Positions position)
        {
            return position switch
            {
                Positions.Assistant => 100.0,
                Positions.Performer => 200.0,
                Positions.Manager => 1000.0,
                Positions.Boss => 100000.0,
                _ => throw new Exception("We don't know anything about your position"),
            };
        }

        public static Responsibilities[] GetResponsibilities(Positions position)
        {
            return position switch
            {
                Positions.Assistant => new[] { Responsibilities.cleaning, Responsibilities.coffee, Responsibilities.letters, Responsibilities.make_mistakes },
                Positions.Performer => new[] { Responsibilities.work_overtime, Responsibilities.write_code },
                Positions.Manager => new[] { Responsibilities.payments, Responsibilities.tasks },
                Positions.Boss => new[] { Responsibilities.behold },
                _ => throw new Exception("We don't know anything about your position"),
            };
        }
        public static Positions GetPromotion(Positions position)
        {
            return position switch
            {
                Positions.Assistant => Positions.Performer,
                Positions.Performer => Positions.Manager,
                Positions.Manager => Positions.Boss,
                Positions.Boss => throw new ArgumentOutOfRangeException("Only stars above"),
                _ => throw new Exception("We don't know anything about your position"),
            };
        }
    }
}