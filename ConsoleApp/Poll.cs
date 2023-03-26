namespace ConsoleApp
{
    public class Poll
    {
        public string Topic { get; init; }
        public List<PollOption> Options { get; private set; }
        public Poll(string question, params string[] options)
        {
            if (options.Length < 2)
            {
                throw new ArgumentException("Number of options of poll should be at least 2.");
            }
            if (string.IsNullOrEmpty(question))
            {
                throw new ArgumentException("Try with another topic.");
            }

            Topic = question;
            Options = new(options.Select(x => new PollOption(x)));
        }
        public Poll(string question, IEnumerable<PollOption> options)
        {
            if (options.Count() < 2)
            {
                throw new ArgumentException("Number of options of poll should be at least 2.");
            }
            if (string.IsNullOrEmpty(question))
            {
                throw new ArgumentException("Try with another topic.");
            }

            Topic = question;
            Options = new(options);
        }
        public Poll(string question, IEnumerable<string> options)
        {
            if (options.Count() < 2)
            {
                throw new ArgumentException("Number of options of poll should be at least 2.");
            }
            if (string.IsNullOrEmpty(question))
            {
                throw new ArgumentException("Try with another topic.");
            }

            Topic = question;
            Options = new(options.Select(x => new PollOption(x)));
        }

        public void DisplayOptions()
        {
            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Options[i]}");
            }
        }
        public void Vote(int number)
        {
            Options[number - 1].Vote();
        }

        public override string? ToString()
        {
            return Topic;
        }
    }
}