using System.Text;

const string filename = "dump.csv";
(string name, DateTime start, int duration, string roomName)[] meetings;

void Menu()
{
    Console.Clear();

    Console.WriteLine("Meeting Booker");
    Console.WriteLine();
    Console.WriteLine("1. Create a meeting");
    Console.WriteLine("2. Show all meetings");
    Console.WriteLine("3. Search by room");
    Console.WriteLine("4. Update meeting");
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
        ShowByName();
    }
    else if (key.Key == ConsoleKey.D4)
    {
        UpdateMeeting();
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
    if (DoesIntersectWithOther(meetings, meeting))
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

void UpdateMeeting()
{
    Console.Clear();

    string meetingName = EnterMeetingName();
    (string, DateTime, int, string) meeting = (null, DateTime.MinValue, 0, null);
    int index = -1;

    for (int i = 0; i < meetings.Length; i++)
    {
        if (meetings[i].Item1 == meetingName)
        {
            meeting = meetings[i];
            index = i;
            break;
        }
    }

    if (index == -1)
    {
        Console.WriteLine("Meeting not found!");
    }
    else
    {
        meeting.Item2 = EnterMeetingStart();
        meeting.Item3 = MeetingDurationInMinutes();
        meeting.Item4 = EnterRoomName();

        (string, DateTime, int, string)[] newMeetings = new (string, DateTime, int, string)[meetings.Length - 1];
        if (index > 0)
        {
            Array.Copy(meetings[..index], newMeetings, index);
        }
        if (index < meetings.Length - 1)
        {
            Array.Copy(meetings[(index + 1)..], 0, newMeetings, index, meetings.Length - index - 1);
        }

        if (DoesIntersectWithOther(newMeetings, meeting))
        {
            Console.WriteLine("Meeting intersects with another!");
        }
        else
        {
            meetings[index] = meeting;
            DumpToFile();

            Console.WriteLine("Meeting successfully updated!");
        }
    }

    Console.WriteLine("To continue press ENTER...");
    _ = Console.ReadLine();
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

    void ShowByName()
    {
        Console.Clear();
        string checkedRoom = EnterRoomName();
        int successCounter = 0;
        foreach (var meeting in meetings)
        {
            if (meeting.roomName == checkedRoom)
            {
                ShowTableHeader();
                ShowMeeting(meeting);
                successCounter++;
            }
        }
        if (successCounter == 0)
        {
            Console.WriteLine("No meetings in this room");
        }

        Console.ReadLine();

    }

  bool DoesIntersectWithOther(
    (string name, DateTime start, int duration, string room)[] meetings,
    (string name, DateTime start, int duration, string room) meeting
)
{
    foreach ((string name, DateTime start, int duration, string room) in meetings)
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

        ShowTableHeader();
        foreach (var meeting in meetings)
        {
            ShowMeeting(meeting);
        }

        Console.WriteLine();
        Console.WriteLine("To continue press ENTER...");
        _ = Console.ReadLine();
    }

    void ShowTableHeader()
    {
        Console.WriteLine($"{"Name",-25}{"Start",-25}{"End",-25}{"Room",-25}");
    }

    void ShowMeeting((string name, DateTime start, int duration, string room) meeting)
    {
        DateTime end = meeting.start.AddMinutes(meeting.duration);
        Console.WriteLine($"{meeting.name,-25}{meeting.start,-25}{end,-25}{meeting.room,-25}");
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

