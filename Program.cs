using ConsoleApp;

List<Vote> allVotes = new List<Vote>();

void Menu()
{
    Console.Clear();

    Console.WriteLine("Vote program");
    Console.WriteLine();
    Console.WriteLine("1. Create vote");
    Console.WriteLine("2. Vote");
    Console.WriteLine("3. See voting results");
    Console.WriteLine("0. Exit");

    ConsoleKeyInfo key = Console.ReadKey();
    if (key.Key == ConsoleKey.D0)
    {
        Exit();
    }
    else if (key.Key == ConsoleKey.D1)
    {
        CreateVote();
    }
    else if (key.Key == ConsoleKey.D2)
    {
        Vote();
    }
    else if (key.Key == ConsoleKey.D3)
    {
        SeeResults();
    }
}

static void Exit()
{
    Environment.Exit(0);
}

void CreateVote()
{
    Console.Clear();
    Vote vote = new Vote();
    vote.voteName = EnterVotingName();
    vote.optionsCount = EnterVotingCount();
    int count = vote.optionsCount;
    vote.options = new string[count];
    vote.options = EnterOptions(vote.options, count);

    vote.votes = new int[count];
    for (int i = 0; i < count; i++)
    {
        vote.votes[i] = 0;
    }

    allVotes.Add(vote);
    Console.WriteLine("Meeting successfully created! To continue press ENTER!");
     _ = Console.ReadLine();
}

void Vote()
{
    while (true)
    {
        if (allVotes.Count != 0)
        {
            Console.WriteLine("Vote events: ");
            foreach (Vote item in allVotes)
            {
                Console.WriteLine(item.voteName);
            }
            Console.WriteLine("Choose vote event by name: ");
            string result = Console.ReadLine();

            foreach (Vote item in allVotes)
            {
                if (item.voteName == result)
                {
                    AddVote(item);
                    return;
                }
            }
            Console.WriteLine("There is no vote with this name!");
            continue;
        }
        Console.WriteLine("There is no votes! To continue press ENTER!");
        _ = Console.ReadLine();
        return;
    }
}

void AddVote(Vote item)
{
    while (true) 
    {
        Console.WriteLine("Choose option to vote for (type number): ");
        for (int i = 0; i < item.optionsCount; i++)
        {
            Console.WriteLine($"{i+1}: {item.options[i]}");
        }
        
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Input should be not empty!");
            continue;
        }

        if(Int32.TryParse(input, out int num))
        {
            if (num > item.optionsCount)
            {
                Console.WriteLine("There is no such option!");
                continue;
            }
            item.votes[num - 1] += 1;
            Console.WriteLine("You successfully voted! To continue press ENTER!");
            _ = Console.ReadLine();
            return;
        }
        else
        {
            Console.WriteLine("You should input a number!");
            continue;
        }

    }
}

string EnterVotingName()
{
    while (true)
    {
        Console.WriteLine("Enter vote name:");
        string input = Console.ReadLine();
        bool isRepeat = false;

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Vote name should be not empty!");
            continue;
        }

        if (input.Length > 20)
        {
            Console.WriteLine("Vote name length should be less than 20!");
            continue;
        }

        foreach (Vote item in allVotes)
        {
            if (item.voteName == input)
            {
                isRepeat = true;
            }
        }
        if (isRepeat == true)
        {
            Console.WriteLine("Vote names can't repeat!");
            continue;
        }

        return input;
    }
}

int EnterVotingCount()
{
    while (true)
    {
        Console.WriteLine("Enter amount of options:");
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Amount of options should be not empty!");
            continue;
        }
        if(Int32.TryParse(input, out int i))
        {
            if (i > 5)
            {
                Console.WriteLine("Amount of options should be less than 5!");
                continue;
            }
        }
        else
        {
            Console.WriteLine("You should input a number!");
            continue;
        }
        return i;
    }
}

string isOptionValid(int i)
{
    while (true)
    {
        Console.WriteLine($"Enter {i+1} option: ");
        string option = Console.ReadLine(); 
        if (string.IsNullOrWhiteSpace(option))
        {
            Console.WriteLine("Amount of options should be not empty!");
            continue;
        }
        if (option.Length > 20)
        {
            Console.WriteLine("Vote name length should be less than 20!");
            continue;
        }
        return option;
    }

}

string[] EnterOptions(string[] options, int count)
{
    while (true)
    {
        for (int i = 0; i < count; i++)
        {
            options[i] = isOptionValid(i);
        }
        return options;
    }
}

void SeeResults()
{
    Console.Clear();
    if (allVotes.Count != 0)
    {
        for (int i = 0; i < allVotes.Count; i++)
        {
            Console.WriteLine($"{i+1}: {allVotes[i].voteName}");  
            for (int j = 0; j < allVotes[i].optionsCount; j++)
            {
                System.Console.WriteLine($"   {allVotes[i].options[j]}: {allVotes[i].votes[j]}");
            }
        }
        Console.WriteLine("To continue press ENTER!");
        _ = Console.ReadLine();
        return;
    }
    Console.WriteLine("There is no votes! To continue press ENTER!");
    _ = Console.ReadLine();
}

while (true)
{
    Menu();
}