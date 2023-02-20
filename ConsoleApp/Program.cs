using System.Text;

const string filename = "dump.csv";
(string, DateTime, int, string)[] meetings;

void Menu()
{
    Console.Clear();

    Console.WriteLine("Meeting Booker");
    Console.WriteLine();
    Console.WriteLine("1. Create a meeting");
    Console.WriteLine("2. Show all meetings");
    Console.WriteLine("3. Update meeting by name");
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
    else if (key.Key == ConsoleKey.D2)
    {
        ShowMeetings();
    }
    else if (key.Key == ConsoleKey.D3)
    {
        UpdateMeetingByName();
    }
}

static void Exit()
{
    Environment.Exit(0);
}

void CreateMeeting()
{
    Console.Clear();

    string meetingName = EnterMeetingName();
    DateTime meetingStart = EnterMeetingStart();
    int meetingDuration = MeetingDurationInMinutes();
    string roomName = EnterRoomName();

    (string, DateTime, int, string) meeting = (meetingName, meetingStart, meetingDuration, roomName);
    if (DoesIntersectWithOther(meeting, meetings))
    {
        Console.WriteLine("Meeting intersects with another!");
    }
    else
    {
        Array.Resize(ref meetings, meetings.Length + 1);
        meetings[^1] = meeting;

        DumpToFile();

        Console.WriteLine("Meeting successfully created!");
    }

    Console.WriteLine("To continue press ENTER...");
    _ = Console.ReadLine();
}

void UpdateMeetingByName()
{
    Console.Clear();
    Console.WriteLine("We need meeting name");
    string meetingName = EnterMeetingName();
    int count = 0;
    foreach ((string name, DateTime start, int duration, string room) in meetings)
    {
        if (name == meetingName)
        {
            count++;
        }
    }
    if (count == 0)
    {
        Console.WriteLine("Sorry, we cannot find meetings with this name");

        Console.WriteLine("To continue press ENTER...");
        _ = Console.ReadLine();
        return;
    }
    DateTime meetingStart = EnterMeetingStart();
    int meetingDuration = MeetingDurationInMinutes();

    (string, DateTime, int, string)[] updatedMeetings;
    updatedMeetings = Array.Empty<(string, DateTime, int, string)>();
    (string, DateTime, int, string)[] nonupdatedMeetings;
    nonupdatedMeetings = Array.Empty<(string, DateTime, int, string)>();

    foreach ((string name, DateTime start, int duration, string room) in meetings)
    {
        if (name == meetingName)
        {
            Array.Resize(ref updatedMeetings, updatedMeetings.Length + 1);
            updatedMeetings[^1] = (name, meetingStart, meetingDuration, room);
        }
        else
        {
            Array.Resize(ref nonupdatedMeetings, nonupdatedMeetings.Length + 1);
            nonupdatedMeetings[^1] = (name, start, duration, room);
        }
    }

    bool intersection = false;
    foreach ((string name, DateTime start, int duration, string room) in updatedMeetings)
    {
        intersection = DoesIntersectWithOther((name, start, duration, room), nonupdatedMeetings);
        if (intersection)
        {
            break;
        }
    }

    if (intersection)
    {
        Console.WriteLine("Meeting intersects with another!");
    }
    else
    {
        foreach ((string name, DateTime start, int duration, string room) in updatedMeetings)
        {
            Array.Resize(ref nonupdatedMeetings, nonupdatedMeetings.Length + 1);
            nonupdatedMeetings[^1] = (name, start, duration, room);
        }
        meetings = nonupdatedMeetings;
        DumpToFile();

        Console.WriteLine("Meeting successfully updated!");
    }

    Console.WriteLine("To continue press ENTER...");
    _ = Console.ReadLine();




}

string EnterMeetingName()
{
    while (true)
    {
        Console.WriteLine("Enter meeting name:");
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Meeting name should be not empty!");
            continue;
        }

        if (input.Length > 20)
        {
            Console.WriteLine("Meeting name length should be less than 20!");
            continue;
        }

        return input;
    }
}

DateTime EnterMeetingStart()
{
    while (true)
    {
        Console.WriteLine("Enter meeting start:");
        string input = Console.ReadLine();

        if (!DateTime.TryParse(input, out DateTime start))
        {
            Console.WriteLine("Meeting start should be valid timestamp!");
            continue;
        }

        if (start <= DateTime.Now)
        {
            Console.WriteLine("Meeting start should be in future!");
            continue;
        }

        return start;
    }
}

int MeetingDurationInMinutes()
{
    while (true)
    {
        Console.WriteLine("Enter meeting duration (in minutes):");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int duration))
        {
            Console.WriteLine("Meeting duration should be valid number!");
            continue;
        }

        if (duration <= 0)
        {
            Console.WriteLine("Meeting duration should be positive number!");
            continue;
        }

        return duration;
    }
}

string EnterRoomName()
{
    while (true)
    {
        Console.WriteLine("Enter room name:");
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Room name should be not empty!");
            continue;
        }

        if (input.Length > 20)
        {
            Console.WriteLine("Room name length should be less than 20!");
            continue;
        }

        return input;
    }
}

bool DoesIntersectWithOther((string name, DateTime start, int duration, string room) meeting, (string, DateTime, int, string)[] arrayOfMeetings)
{
    foreach ((string name, DateTime start, int duration, string room) in arrayOfMeetings)
    {
        if (meeting.room == room)
        {
            DateTime end1 = meeting.start.AddMinutes(meeting.duration);
            DateTime end2 = start.AddMinutes(duration);

            if (meeting.start >= start && meeting.start < end2)
            {
                return true;
            }

            if (start >= meeting.start && start < end1)
            {
                return true;
            }
        }
    }

    return false;
}

void ShowMeetings()
{
    Console.Clear();

    Console.WriteLine($"{"Name",-25}{"Start",-25}{"End",-25}{"Room",-25}");
    foreach ((string name, DateTime start, int duration, string room) in meetings)
    {
        DateTime end = start.AddMinutes(duration);
        Console.WriteLine($"{name,-25}{start,-25}{end,-25}{room,-25}");
    }

    Console.WriteLine();
    Console.WriteLine("To continue press ENTER...");
    _ = Console.ReadLine();
}

void DumpToFile()
{
    StringBuilder sb = new();
    _ = sb.AppendLine("Name,Start,Duration,Room");
    foreach ((string name, DateTime start, int duration, string room) in meetings)
    {
        _ = sb.AppendLine($"{name},{start},{duration},{room}");
    }

    File.WriteAllText(filename, sb.ToString());
}

void LoadFromFile()
{
    if (!File.Exists(filename))
    {
        meetings = Array.Empty<(string, DateTime, int, string)>();
        return;
    }

    string[] lines = File.ReadAllLines(filename);
    meetings = new (string, DateTime, int, string)[lines.Length - 1];

    for (int i = 1; i < lines.Length; i++)
    {
        string line = lines[i];
        string[] items = line.Split(',');
        meetings[i - 1] = (items[0], DateTime.Parse(items[1]), int.Parse(items[2]), items[3]);
    }
}

LoadFromFile();
while (true)
{
    Menu();
}
