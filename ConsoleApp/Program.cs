using System;
using System.Collections.Generic;

using ConsoleApp;

IndexDictionary<string, IndexDictionary<string, int>> listOfTopics = new IndexDictionary<string, IndexDictionary<string, int>>();
void Menu()
{
    Console.Clear();

    Console.WriteLine("Voting system");
    Console.WriteLine();
    Console.WriteLine("1. Create vote topic");
    Console.WriteLine("2. Vote");
    Console.WriteLine("3. Results");
    Console.WriteLine("0. Exit");

    ConsoleKeyInfo key = Console.ReadKey();
    if (key.Key == ConsoleKey.D0)
    {
        Exit();
    }
    if (key.Key == ConsoleKey.D1)
    {
        CreateVoteTopic();
    }
    if (key.Key == ConsoleKey.D2)
    {
        Vote();
    }
    if (key.Key == ConsoleKey.D3)
    {
        Results();
    }
}

void CreateVoteTopic()
{
    Console.Clear();
    if (listOfTopics.Count > 8)
    {
        Console.WriteLine("You cannot create more than 9 topics!");
        ToContinuePressEnter();
    }
    string input = TopicNameValidation();
    VotingOptionsBuilder vob = new VotingOptionsBuilder();
    vob.AddOption();
    listOfTopics[input] = vob.GetVotingOptions();
    Console.WriteLine("Topic for voting succesfully created!");
    ToContinuePressEnter();
}

void Vote()
{
    Console.Clear();
    if (IsListEmpty())
    {
        return;
    }
    ChooseTopic(out string topicName);
    IndexDictionary<string, int> options = listOfTopics[topicName];
    while (true)
    {
        Console.Clear();
        Console.WriteLine($"Vote for {topicName}");
        options.WriteKeyList();
        bool keyInList = IsKeyNumberInRange(out int valueIndex, options.Count);
        if (keyInList)
        {
            listOfTopics[topicName][options.GetKeyByIndex(valueIndex)]++;
            ToContinuePressEnter();
            return;
        }
    }
}


void Results()
{
    Console.Clear();
    if (IsListEmpty())
    {
        return;
    }
    ChooseTopic(out string topicName);
    Console.Clear();
    Console.WriteLine(topicName);
    foreach (KeyValuePair<string, int> kvp in listOfTopics[topicName])
    {
        Console.WriteLine($"{kvp.Key} - {kvp.Value} vote(s)");
    }
    ToContinuePressEnter();
}

void ToContinuePressEnter()
{
    Console.WriteLine();
    Console.WriteLine("To continue press any key...");
    _ = Console.ReadKey();
}

void Exit()
{
    Console.Clear();
    Environment.Exit(0);
}

void ChooseTopic(out string key)
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Choose topic:");
        Console.WriteLine();
        listOfTopics.WriteKeyList();
        bool keyInList = IsKeyNumberInRange(out int index, listOfTopics.Count);
        if (keyInList)
        {
            key = listOfTopics.GetKeyByIndex(index);
            break;
        }
    }
}

bool IsKeyNumberInRange(out int index, int range)
{
    index = 0;
    char countChar = char.Parse(range.ToString());
    ConsoleKeyInfo key = Console.ReadKey();
    bool result = (key.KeyChar > '0') && (key.KeyChar <= countChar);
    if (result)
    {
        index = int.Parse(key.KeyChar.ToString()) - 1;
    }
    return result;
}

bool IsListEmpty()
{
    bool result = listOfTopics.Count == 0;
    if (result)
    {
        Console.WriteLine("Topic list is empty!");
        ToContinuePressEnter();
    }
    return result;
}

string TopicNameValidation()
{
    while (true)
    {
        Console.WriteLine("Enter topic name:");
        string input = Console.ReadLine();
        if (String.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Topic name must be not empty!");
            continue;
        }
        if (!listOfTopics.TryAdd(input, new IndexDictionary<string, int>()))
        {
            Console.WriteLine("Topic with this name already exist!");
            continue;
        }
        return input;
    }
}

while (true)
{
    Menu();
}