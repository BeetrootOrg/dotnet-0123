namespace ConsoleApp
{
    internal class CovidInfo
    {
        public Summary SummaryStats {get; init;}
    }

    internal class Summary
    {
        public Statistic Global {get; init;}
        public Statistic China {get; init;}
        public Statistic NonChina {get; init;}
    }

    internal class Statistic
    {
        public long? Confirmed { get; init; }
        public long? Recovered { get; init; }
        public long? Deaths { get; init; }
    }
}