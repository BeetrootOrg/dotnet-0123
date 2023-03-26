using ConsoleApp;


List<Poll> polls = new List<Poll>();
ConsoleKey key = new();
do
{
    DisplayMenu();
    key = Console.ReadKey(true).Key;
    if (key == ConsoleKey.D1)
    {
        Console.WriteLine("Enter topic name:");
        string? topic = string.Empty;
        while (topic == string.Empty)
        {
            topic = Console.ReadLine();
        }

        List<string> options = new List<string>();
        string? option;
        do
        {
            Console.WriteLine("Enter vote option (press enter if all options added):");
            option = Console.ReadLine();
            if (option != string.Empty)
            {
                options.Add(option);
            }
        } while (option != string.Empty || options.Count < 2);

        Poll poll = new Poll(topic, options);
        polls.Add(poll);
        Console.WriteLine("Topic created.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }
    else if (key == ConsoleKey.D2)
    {
        if (polls.Count == 0)
        {
            Console.WriteLine("There is no vote topics now :(");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            continue;
        }

        DisplayTopics();
        int topicNumber = -1;
        while (!int.TryParse(Console.ReadLine(), out topicNumber) ||
               (topicNumber < 0 || topicNumber > polls.Count))
        {
            DisplayTopics();
        }
        if (topicNumber == 0)
        {
            continue;
        }

        DisplayVote(topicNumber - 1);
        int voteNumber = -1;
        while (!int.TryParse(Console.ReadLine(), out voteNumber) ||
               (voteNumber < 1 || voteNumber > polls[topicNumber - 1].Options.Count))
        {
            DisplayVote(topicNumber - 1);
        }
        polls[topicNumber - 1].Vote(voteNumber);

        Console.WriteLine("Vote added.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }
    else if (key == ConsoleKey.D3)
    {
        if (polls.Count == 0)
        {
            Console.WriteLine("There is no results now :(");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            continue;
        }

        DisplayTopics();
        int topicNumber = -1;
        while (!int.TryParse(Console.ReadLine(), out topicNumber) ||
               (topicNumber < 0 || topicNumber > polls.Count))
        {
            DisplayTopics();
        }
        if (topicNumber == 0)
        {
            continue;
        }

        Console.WriteLine($"{polls[topicNumber - 1]}");
        foreach (var option in polls[topicNumber - 1].Options)
        {
            Console.WriteLine($"{option.Label} - {option.TotalVotes} vote(s)");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }

}
while (key != ConsoleKey.D0);

void DisplayVote(int index)
{
    Console.WriteLine($"Vote for: {polls[index]}");
    polls[index].DisplayOptions();
}
void DisplayMenu()
{
    Console.WriteLine("\nMenu:\n1. Create vote topic\n2. Vote\n3. Results\n0. Exit\n");
}
void DisplayTopics()
{
    Console.WriteLine("Choose topic:");
    for (int i = 0; i < polls.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {polls[i]}");
    }
    Console.WriteLine("0. Back to menu");
}