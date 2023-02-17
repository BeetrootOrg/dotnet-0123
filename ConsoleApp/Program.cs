(string, DateTime, int, string)[] meetings = Array.Empty<(string, DateTime, int, string)>();

void Menu()
{
    Console.Clear();

    Console.WriteLine("Meeting Booker");
    Console.WriteLine();
    Console.WriteLine("1. Create a meeting");
    Console.WriteLine("2. Show all meetings");
    Console.WriteLine("0. Exit");

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

    Console.WriteLine("Enter meeting name:");
    string meetingName = Console.ReadLine();

    Console.WriteLine("Enter meeting start:");
    string meetingStartInput = Console.ReadLine();
    DateTime meetingStart = DateTime.Parse(meetingStartInput);

    Console.WriteLine("Enter meeting duration (in minutes):");
    string meetingDurationInput = Console.ReadLine();
    int meetingDuration = int.Parse(meetingDurationInput);

    Console.WriteLine("Room name:");
    string roomName = Console.ReadLine();

    Array.Resize(ref meetings, meetings.Length + 1);
    meetings[^1] = (meetingName, meetingStart, meetingDuration, roomName);

    Console.WriteLine("Meeting successfully created!");
    Console.WriteLine("To continue press ENTER...");
    _ = Console.ReadLine();
}

while (true)
{
    Menu();
}
