using ConsoleApp;

TopicList topicList = new TopicList();
OptionList optionList = new OptionList();

void App()
{
    Menu.Show();
    ConsoleKeyInfo key = Console.ReadKey();

    if (key.Key == ConsoleKey.D0)
    {
        Environment.Exit(0);
    }
    else if (key.Key == ConsoleKey.D1)
    {
        CreateTopic();
    }
    else if (key.Key == ConsoleKey.D2)
    {
        Vote();
    }
    else if (key.Key == ConsoleKey.D3)
    {
        ShowResults();
    }
}

void CreateTopic()
{
    Console.Clear();
    Console.WriteLine("Enter topic name:");
    string name = Input.ValidteString();

    Topic topic = new Topic(name);
    topicList.Add(topic);
 
    int counter = 0;

    while (true)
    {
        Console.WriteLine("Enter vote option (press enter if all options added):");
        string option = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(option))
        {
            if (counter < 2)
            {
                Console.WriteLine($"Error! You need to enter at least two options");
                continue;
            }
            break;
        }

        optionList.Add(new Option(++counter, topic.Id, option));
    }

    Input.Return();
}

void Vote()
{
    Console.Clear();
    Console.WriteLine("Choose topic:");
    topicList.Menu();

    while(true)
    {
        string input = Console.ReadLine();
        
        if (!int.TryParse(input, out int topicId))
        {
            Console.WriteLine("Error! Your choice is not valid. Try again:");
            continue;
        }
        
        if (topicId == 0)
        {
            break;
        }

        if (!topicList.ItemExists(topicId))
        {
            Console.WriteLine("Error! Wrong choice. Try again:");
            continue;
        }

        Console.WriteLine($"Vote for: {topicList.GetNameById(topicId)}");
        optionList.SubMenu(topicId);

        while(true)
        {
            input = Console.ReadLine();
            
            if (!int.TryParse(input, out int optionId))
            {
                Console.WriteLine("Error! Your choice is not valid. Try again:");
                continue;
            }
            
            if (optionId == 0)
            {
                break;
            }

            if (!optionList.ItemExists(optionId, topicId))
            {
                Console.WriteLine("Error! Wrong choice. Try again:");
                continue;
            }

            optionList.AddVote(optionId, topicId);
            Console.WriteLine("Vote added");
            break;
        }

        Input.Return();
        break;
    }

}

void ShowResults()
{
    Console.Clear();
    Console.WriteLine("Choose topic:");
    topicList.Menu();

    while(true)
    {
        string input = Console.ReadLine();
        
        if (!int.TryParse(input, out int topicId))
        {
            Console.WriteLine("Error! Your choice is not valid. Try again:");
            continue;
        }
        
        if (topicId == 0)
        {
            break;
        }

        if (!topicList.ItemExists(topicId))
        {
            Console.WriteLine("Error! Wrong choice. Try again:");
            continue;
        }

        optionList.Show(topicId);

        Input.Return();
        break;
    }
}

while (true)
{
    App();
}
