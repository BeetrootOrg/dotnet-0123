using System;

(string, DateTime, int, string)[] = Array.Empty<(string, DateTime, int, string)>();

void Menu()
{
    Console.Clear();

    Console.WriteLine("Meeting Booker");
    Console.WriteLine();
    Console.WriteLine("1.Create a meeting");
    Console.WriteLine("2.Show all meetings");
    Console.WriteLine("0.Exit");
    
    ConsoleKeyInfo key = Console.ReadKey();
    if (key.Key == ConsoleKey.D0)
    {
        Exit();
    }
    else if (key.Key == ConsoleKey.D1)
    {
        CreateMeeting();
    }
}

static void Exit()
{
    Environment.Exit(0);
}

void CreateMeeting()
{
    Console.Clear();

    Console.WriteLine("enter meeting time:");
    string meetingName = Console.ReadLine();

    Console.WriteLine("enter meeting start:");
    string meetingStartInput = Console.ReadLine();
    DateTime meetingStart = DateTime.Parse(meetingStartInput);
}

while (true)
{
    Menu();
}