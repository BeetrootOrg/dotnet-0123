using System.Text;

const string filename = "dump.csv";
const string logfile = "log.txt";
(string, DateTime, int, string)[] meetings;

void Menu()
{
    Console.Clear();

    Console.WriteLine("Meeting Booker");
    Console.WriteLine();
    Console.WriteLine("1. Create a meeting");
    Console.WriteLine("2. Show all meetings");
    Console.WriteLine("3. Update meeting");
    Console.WriteLine("4. Update meeting by name");
    Console.WriteLine("5. Search by room");
    Console.WriteLine("6. Search by date range");

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
        UpdateMeeting();
    }
    else if (key.Key == ConsoleKey.D4)
    {
        UpdateMeetingByName();
    }
    else if (key.Key == ConsoleKey.D5)
    {
        SearchByRoom();
    }
    else if (key.Key == ConsoleKey.D6)
    {
        SearchByDateRange();
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
    try
    {
        VerifyNotIntersectWithOther(meetings, meeting);

        Array.Resize(ref meetings, meetings.Length + 1);
        meetings[^1] = meeting;

        DumpToFile();

        Console.WriteLine("Meeting successfully created!");
    }
    catch (ArgumentException ae)
    {
       Console.WriteLine(ae.Message);
    }

    Console.WriteLine("To continue press ENTER...");
    _ = Console.ReadLine();
}

void DataCorrupted()
{
     meetings = Array.Empty<(string, DateTime, int, string)>();
            
    Console.Clear();
    Console.WriteLine("Data Corrupted");
    Console.WriteLine("To continue press ENTER...");
    _ = Console.ReadLine();
}

void AppendError(Exception e)
{
    File.AppendAllLines(logfile, new[] {e.Message, e.StackTrace});
    //File.AppendAllText(logfile, e.Message);
    //File.AppendAllText(logfile, e.StackTrace);
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

        if (VerifyNotIntersectWithOther(newMeetings, meeting))
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

string EnterMeetingName()
{
    while (true)
    {
        Console.WriteLine("Enter meeting name:");
        string input = Console.ReadLine();
    	try
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException();
            }

            if (input.Length > 20)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Meeting name should be not empty!");
            continue;
        }
        catch (ArgumentOutOfRangeException)
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
            throw new ArgumentException("Meeting start should be valid timestamp!");
        }

        if (start <= DateTime.Now)
        {
            throw new ArgumentException("Meeting start should be in future!");
        }

        return start;
    }
}

DateTime EnterSearchMeetingDateTime(string message)
{
    while (true)
    {
        Console.WriteLine(message);
        string input = Console.ReadLine();

        if (!DateTime.TryParse(input, out DateTime start))
        {
            Console.WriteLine("Meeting start should be valid timestamp!");
            continue;
        }

        return start;
    }
}

DateTime EnterSearchMeetingStart()
{
    return EnterSearchMeetingDateTime("Enter meeting start:");
}

DateTime EnterSearchMeetingEnd()
{
    return EnterSearchMeetingDateTime("Enter meeting end:");
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

        try
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException();
            }

            if (input.Length > 20)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Room name should be not empty!");
            continue;
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Room name length should be less than 20!");
            continue;
        }
        
        return input;
    }
}

bool VerifyNotIntersectWithOther(
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
                throw new ArgumentException($"Meeting '{name}' intersects with '{meeting.name}'!");
            }

            if (start >= meeting.start && start < end1)
            {
                throw new ArgumentException($"Meeting '{name}' intersects with '{meeting.name}'!");
            }
        }
    }

    return false;
}

void UpdateMeetingByName()
{
    throw new NotImplementedException();
}

void ShowMeetings()
{
    ShowCurrentMeetings(meetings);
}

void ShowCurrentMeetings((string, DateTime, int, string)[] meetings)
{
    Console.Clear();
    WriteMeeting(meetings);
    Console.WriteLine();
    Console.WriteLine("To continue press ENTER...");
    _ = Console.ReadLine();
}

void WriteMeeting((string, DateTime, int, string)[] meetings)
{
    Console.WriteLine($"{"Name",-25}{"Start",-25}{"End",-25}{"Room",-25}");
    foreach ((string name, DateTime start, int duration, string room) in meetings)
    {
        DateTime end = start.AddMinutes(duration);
        Console.WriteLine($"{name,-25}{start,-25}{end,-25}{room,-25}");
    }
}

void SearchByDateRange()
{
    Console.Clear();
    DateTime start = EnterSearchMeetingStart();
    DateTime end = EnterSearchMeetingEnd();

    (string name, DateTime start, int duration, string room)[] filtered = Array.Empty<(string, DateTime, int, string)>();
    foreach ((string, DateTime, int, string) meeting in meetings)
    {
        if (meeting.Item2 >= start && meeting.Item2 <= end)
        {
            Array.Resize(ref filtered, filtered.Length + 1);
            filtered[^1] = meeting;
        }
    }

    ShowCurrentMeetings(filtered);
}

void SearchByRoom()
{
    Console.Clear();
    string roomName = EnterRoomName();
    (string name, DateTime start, int duration, string room)[] filtered = Array.Empty<(string, DateTime, int, string)>();

    foreach ((string, DateTime, int, string) meeting in meetings)
    {
        if (meeting.Item4 == roomName)
        {
            Array.Resize(ref filtered, filtered.Length + 1);
            filtered[^1] = meeting;
        }
    }

    ShowCurrentMeetings(filtered);
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

        try
        {
            meetings[i - 1] = (items[0], DateTime.Parse(items[1]), int.Parse(items[2]), items[3]);
        }
        catch (IndexOutOfRangeException ioore)
        {
            AppendError(ioore);

            if (items.Length == 3)
            {
                bool dateTimeParse = DateTime.TryParse(items[1], out DateTime start);
                bool durationParse = int.TryParse(items[2], out int duration);
                if (dateTimeParse && durationParse)
                {
                    meetings[i - 1] = (items[0], start, duration, "unknown");
                }
            }       
        }
        catch (Exception e)
        {
            AppendError(e);
            DataCorrupted();

            return;
        }
    }
}

LoadFromFile();
while (true)
{
    try
    {
        Menu();
    }
    catch (Exception e)
    {
        AppendError(e);
        throw;
    }
}