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
    Console.WriteLine("4. Show meetings by room");
    Console.WriteLine("5. Show meetings by date range");
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
        ShowMeetingsByRoom();
    }
    else if (key.Key == ConsoleKey.D5)
    {
        ShowMeetingsByDateRange();
    }
}

static void Exit()
{
    Environment.Exit(0);
}

void CreateMeeting()
{
    Console.Clear();

    string meetingName = InputString("Enter meeting name:");
    DateTime meetingStart = InputDate("Enter meeting start:");
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

string InputString(string title)
{
    while (true)
    {
        Console.WriteLine(title);
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

DateTime InputDate(string title, bool onlyFuture = true)
{
    while (true)
    {
        Console.WriteLine(title);
        string input = Console.ReadLine();

        if (!DateTime.TryParse(input, out DateTime start))
        {
            Console.WriteLine("Meeting start should be valid timestamp!");
            continue;
        }

        if (start <= DateTime.Now && onlyFuture == true)
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

bool DoesIntersectWithOther((string name, DateTime start, int duration, string room) meeting, string exceptName = null, DateTime? exceptStart = null)
{
    foreach ((string name, DateTime start, int duration, string room) in meetings)
    {
        if (name.Equals(exceptName) && start.Equals(exceptStart))
        {
            continue;
        }

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

    if (meetings.Length > 0)
    {
        PrintMeetings(meetings);
    }
    else
    {
        Console.WriteLine("\nNo meetings\n");
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

// HOMEWORK

void UpdateMeeting()
{
    Console.Clear();

    string currentName = InputString("Enter meeting name for update:");
    (string, DateTime, int, string)[] arr = FilterMeetings("name", currentName);

    if (arr.Length == 0)
    {
        Console.WriteLine("No meetings with this name");
    }
    else
    {
        PrintMeetings(arr);
        
        string oldName = arr[0].Item1;
        DateTime oldStart = arr[0].Item2;
        string room = arr[0].Item4;
        
        string newName = InputString("Enter new meeting name:");
        DateTime newStart = InputDate("Enter new meeting start:");
        int newDuration = MeetingDurationInMinutes();

        if (arr.Length == 1 || !IsMeetingNameUnique(arr))
        {
            if (DoesIntersectWithOther((newName, newStart, newDuration, room), oldName, oldStart))
            {
                Console.WriteLine("The new meetings will be intersected with other");
            }
            else
            {
                RewriteMeeting(oldName, room, newName, newStart, newDuration, onlyOnce: true);
            }
        }
        else
        {
            if (DoesUpdatingIntersect(arr, oldName, newStart, newDuration))
            {
                Console.WriteLine("Update not possible! There are datetime intersection with other meetings");
            }
            else
            {
                RewriteMeeting(oldName, room, newName, newStart, newDuration);
            }    
        }
    }

    Console.WriteLine("To continue press ENTER...");
    _ = Console.ReadLine();
}

void ShowMeetingsByRoom()
{
    Console.Clear();

    string room = InputString("Enter a room name:");
    (string, DateTime, int, string)[] arr = FilterMeetings("room", room);
    
    if (arr.Length == 0)
    {
        Console.WriteLine("No meetings in this room");
    }
    else
    {
        PrintMeetings(arr);
    }    

    Console.WriteLine("To continue press ENTER...");
    _ = Console.ReadLine();
}

void ShowMeetingsByDateRange()
{
    Console.Clear();
    DateTime start = InputDate("Enter start of date and time:", false);
    DateTime end = InputDate("Enter end of date and time:", false);

    if (start > end) 
    {
        Console.WriteLine("\nWrong date range!\n");
    }
    else
    {
        (string, DateTime, int, string)[] arr = MeetingsByDateRange(start, end);

        if (arr.Length > 0)
        {
            PrintMeetings(arr);
        }
        else
        {
            Console.WriteLine("\nNo data in that date range\n");
        }    
    }

    Console.WriteLine("To continue press ENTER...");
    _ = Console.ReadLine();
}

(string, DateTime, int, string)[] FilterMeetings(string filterField, string filterValue)
{
    (string, DateTime, int, string)[] arr = new (string, DateTime, int, string)[0];

    foreach((string name, DateTime start, int duration, string room) meeting in meetings)
    {
        string filter; 

        if (filterField == "name")
        {
            filter = meeting.name;
        }
        else if (filterField == "room")
        {
            filter = meeting.room;
        }
        else
        {
            filter = String.Empty;
        }

        if (filterValue == filter)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[^1] = meeting;
        }
    }
    
    return arr;
}

static int CountByNameAndRoom((string, DateTime, int, string)[] meetings, string name, string room)
{
    int count = 0;
    
    foreach ((string name, DateTime start, int duration, string room) meeting in meetings)
    {
        if (meeting.name.Equals(name) && meeting.room.Equals(room))
        {
            count++;
        }
    }

    return count;
}

static bool IsMeetingNameUnique((string, DateTime, int, string)[] meetings)
{
    foreach ((string name, DateTime start, int duration, string room) meeting in meetings)
    {
        int count = CountByNameAndRoom(meetings, meeting.name, meeting.room);
        
        if (count > 1)
        {
            return false;
        }
    }

    return true;
}

void RewriteMeeting(string oldName, string oldRoom, string newName, DateTime newStart, int newDuration, bool onlyOnce = false)
{
    for (int i = 0; i < meetings.Length; i++)
    {
        (string name, DateTime start, int duration, string room) = meetings[i];
        
        if (name.Equals(oldName))
        {
            meetings[i] = (newName, newStart, newDuration, oldRoom);
            if (onlyOnce)
            {
                break;
            }    
        }
    }

    DumpToFile();
}

bool DoesUpdatingIntersect((string, DateTime, int, string)[] updatingMeetings, string currentName, DateTime start, int duration)
{
    foreach ((string name, DateTime, int, string room) updatingMeeting in updatingMeetings)
    {
        (string, DateTime, int, string) meeting = (updatingMeeting.name, start, duration, updatingMeeting.room);
        
        if (DoesIntersectWithOther(meeting, currentName))
        {
            return true;
        }
    }

    return false;
}

(string, DateTime, int, string)[] MeetingsByDateRange(DateTime start, DateTime end)
{
    (string, DateTime, int, string)[] arr = new (string, DateTime, int, string)[0];
    
    foreach((string name, DateTime start, int duration, string room) meeting in meetings)
    {
        DateTime meetingEnd = meeting.start.AddMinutes(meeting.duration);
 
        if (meeting.start >= start && meetingEnd <= end)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[^1] = meeting;
        }
    }
    
    return arr;
}

static void PrintMeetings((string, DateTime, int, string)[] meetings)
{
    Console.WriteLine();
    Console.WriteLine($"{"Name",-25}{"Start",-25}{"End",-25}{"Room",-25}");

    foreach ((string name, DateTime start, int duration, string room) in meetings)
    {
        DateTime end = start.AddMinutes(duration);
        Console.WriteLine($"{name,-25}{start,-25}{end,-25}{room,-25}");
    }

    Console.WriteLine();
}

// END OF HOMEWORK

LoadFromFile();
while (true)
{
    Menu();
}
