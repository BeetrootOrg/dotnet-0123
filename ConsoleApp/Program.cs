static void Menu()
{
    Console.Clear();

    Console.WriteLine("Meeting Booker");
    Console.WriteLine();
    Console.WriteLine("1. Create a meeting");
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

static void CreateMeeting()
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

    Console.WriteLine($"{meetingName} {meetingStart} {meetingDuration} {roomName}");
}

while (true)
{
    Menu();
}
