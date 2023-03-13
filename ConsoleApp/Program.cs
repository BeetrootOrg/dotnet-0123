//======13/03/2023=============
//=====Homework 17-collections
//Create a program to ‘vote’ for anything. Via the console interface users will create a ‘vote topic’ 
//with options. Voters will vote via console interface as well. Users can see voting results via 
//console interface.
using ConsoleApp.Data;
using ConsoleApp.Models;
using ConsoleApp.Helpers;

using System;

var context = new Context();
ShowMainMenu();

void ShowMainMenu()
{
    Console.Clear();
    bool run = true;
    while (run)
    {
        Console.WriteLine("Main Menu:\n\t1. Create Topic;\n\t2. Vote;\n\t3. Results\n\t0. Exit.");
        int? c = Helper.IsValueIntAndInRange(Console.ReadLine(), 0, 3);
        switch (c)
        {
            case 0:
                Console.WriteLine("Bye, bye!");
                run = false;
                break;
            case 1:
                Console.Clear();
                CreateTopic();
                break;
            case 2:
                VoteMenu();
                break;
            case 3:
                Result();
                break;
            default:
                TryMore();
                break;
        }
    }
}

void Result()
{
    Console.Clear();
    Console.WriteLine($"Results:\n{string.Join("\n", context.Topics.Select(x => x.Result()).ToArray())}");
    Console.ReadKey();
    Console.Clear();
}

void Vote(Topic topic, string name)
{
    Console.WriteLine("Please select Option Vote (key Enter to return)");
    Console.WriteLine(topic);
    string s = Console.ReadLine();
    if (string.IsNullOrEmpty(s)) return;
    int? c = Helper.IsValueIntAndInRange(s, topic.Options.Select(x => x.Id).ToList());
    if (c != null)
    {
        topic.CreateVoteUser(name, (int)c);
        Console.WriteLine("Congratulations");
        return;
    }
    TryMore();
    Vote(topic, name);
}

void VoteMenu()
{
    Console.WriteLine("Please select Topic (key Enter for return to Main)");
    Console.WriteLine($"\t{string.Join("\n\t", context.Topics.Select(x => x.MenuItem))}");
    string s = Console.ReadLine();
    if (string.IsNullOrEmpty(s)) return;
    int? c = Helper.IsValueIntAndInRange(s, context.Topics.Select(x => x.Id).ToList());
    if (c != null)
    {
        var top = context.GetToppicById((int)c);
        Console.WriteLine("Please enter your Name (key Enter for return to Previous Menu)");
        string name = Console.ReadLine();
        if (string.IsNullOrEmpty(name)) return;
        if (top.IsUserNameVotes(name))
        {
            Console.WriteLine("You have already voted\n==========");
            return;
        }
        Vote(top, name);
        return;
    }
    TryMore();
    VoteMenu();
}

void CreateTopic()
{
    Console.WriteLine("Create Topic: Please enter Name Topic (key Enter for return to Main)");
    string name = Console.ReadLine();
    if (string.IsNullOrEmpty(name)) return;
    Console.WriteLine("Create Topic: Please enter Description Topic");
    string description = Console.ReadLine();
    var top = context.CreateNewTopic(name, description);
    if (top == null)
    {
        TryMore();
        CreateTopic();
        return;
    }
    while (true)
    {
        Console.WriteLine("Create Option: Please enter Vote Option Name (key Enter for return to Main)");
        string option = Console.ReadLine();
        if (string.IsNullOrEmpty(option))
        {
            Console.WriteLine($"Congratulation Topic Created:\n{top}\n============");
            return;
        }
        if (top.CreateOption(option) == null) Console.WriteLine("Option was not created!");
    }
}

void TryMore()
{
    Console.WriteLine("Something  wrong. Choose more....");
}