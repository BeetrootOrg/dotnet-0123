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
    Console.WriteLine("3. Update meeting");
    Console.WriteLine("4. Show meetings in room");
    Console.WriteLine("0. Exit");

    try
    {
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
            ShowMeetingsByRoom();
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        throw;
    }
    
    
}

static void Exit()
{
    Environment.Exit(0);
}

void CreateMeeting()
{
    try
    {
        Console.Clear();

        string meetingName = EnterMeetingName();
        DateTime meetingStart = EnterMeetingStart();
        int meetingDuration = MeetingDurationInMinutes();
        string roomName = EnterRoomName();

        (string, DateTime, int, string) meeting = (meetingName, meetingStart, meetingDuration, roomName);
        if (DoesIntersectWithOther(meeting))
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
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
    }
}

void UpdateMeeting()
{
    try
    {
        Console.Clear();

        string meetingName = EnterMeetingName();
    
        // Read all lines from the file
        string[] lines = File.ReadAllLines(filename);

        // Loop through each line and find the record with the specified meeting ID
        for (int i = 0; i < lines.Length; i++)
        {
            string[] fields = lines[i].Split(',');
            string name = fields[0];

            if (name == meetingName)
            {
                // Update the record with the new subject and date
                fields[1] = EnterMeetingStart().ToString();
                fields[2] =  MeetingDurationInMinutes().ToString();
                fields[3] =  EnterRoomName();
            
                // Write the updated line back to the file
                lines[i] = string.Join(",", fields);
                File.WriteAllLines(filename, lines);
            
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
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

bool DoesIntersectWithOther((string name, DateTime start, int duration, string room) meeting)
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

void ShowMeetingsByRoom()
{
    Console.Clear();
    string roomName = EnterRoomName();
    int successCounter = 0;
    foreach (var meeting in meetings)
    {
        if (meeting.Item4 == roomName)
        {
            DateTime end = meeting.Item2.AddMinutes(meeting.Item3);
            Console.WriteLine($"{meeting.Item1,-25}{meeting.Item2,-25}{end,-25}{meeting.Item4,-25}");
            successCounter++;
        }
    }
    if (successCounter == 0)
    {
        Console.WriteLine("No meetings in this room");
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