namespace ConsoleApp
{
    public class PollOption
    {
        public string Label { get; init; }
        public int TotalVotes { get; private set; }
        public PollOption(string option)
        {
            if (string.IsNullOrEmpty(option))
            {
                throw new ArgumentException("Wrong label of option of the vote.");
            }
            Label = option;
            TotalVotes = 0;
        }
        public void Vote()
        {
            TotalVotes++;
        }

        public override string? ToString()
        {
            return Label;
        }
    }
}