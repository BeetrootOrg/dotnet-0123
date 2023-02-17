using System.Text;


const string filename = "dump.csv";
(string, DateTime, int, string)[] meetings;


void Menu()
{
    Console.Clear();

    Console.WriteLine("Meeting booker");
    Console.WriteLine("");
    Console.WriteLine("1, Create a meeting");
    Console.WriteLine("2, Show all meetings");
    Console.WriteLine("0, Exit");

    var key = Console.ReadKey();
    if (key.Key == ConsoleKey.D0)
    {
        Exit();
    }
    if (key.Key == ConsoleKey.D1)
    {
        CreateMeeting();
    }
    if (key.Key == ConsoleKey.D2)
    {
        ShowMeeting();
    }
}

void Exit()
{
    Environment.Exit(0);
}

void CreateMeeting()
{
    Console.Clear();
    string meetingName = EnterMeetingName();
    DateTime meetingStart = EnterMeetingTime();
    int meetingDuration = EnterMeetingDuration();
    string roomName = EnterMeetingRoom();

    Array.Resize(ref meetings, meetings.Length + 1);
    meetings[^1] = (meetingName, meetingStart, meetingDuration, roomName);

    DumpToFile();
    
    Console.WriteLine("Press any key");
    Console.ReadLine();
}

string EnterMeetingName()
{
    while (true)
    {
        Console.Clear();
        System.Console.WriteLine("Enter Meeting Name");
        string input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            System.Console.WriteLine("name should be not empty");
            continue;
        }
        if (input.Length > 20)
        {
            System.Console.WriteLine("Should be shorter");
            continue;
        }
        return input;

    }

    Console.WriteLine("Press any key");
    Console.ReadLine();
}

DateTime EnterMeetingTime()
{
    while (true)
    {
        Console.Clear();
        System.Console.WriteLine("Enter Meeting Start");
        string input = Console.ReadLine();
        if (!DateTime.TryParse(input, out DateTime start))
        {
            System.Console.WriteLine("Start should be valid");
            continue;
        }
        if (start <= DateTime.Now)
        {
            System.Console.WriteLine("Should be in future");
            continue;
        }
        return start;
    }
    
    Console.WriteLine("Press any key");
    Console.ReadLine();
}

int EnterMeetingDuration()
{
    while (true)
    {
        Console.Clear();
        System.Console.WriteLine("Enter Meeting Duration");
        string input = Console.ReadLine();
        if (!int.TryParse(input,out int duration))
        {
            System.Console.WriteLine("duration should be valid");
            continue;
        }
        if (duration<=0)
        {
            System.Console.WriteLine("Should be positive");
            continue;
        }
        return duration;

    }
    
    Console.WriteLine("Press any key");
    Console.ReadLine();
}

string EnterMeetingRoom()
{
    while (true)
    {
        Console.Clear();
        System.Console.WriteLine("Enter Meeting Room");
        string input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            System.Console.WriteLine("Room should be not empty");
            continue;
        }
        if (input.Length > 20)
        {
            System.Console.WriteLine("Should be shorter");
            continue;
        }
        return input;

    }
    
    Console.WriteLine("Press any key");
    Console.ReadLine();
}


void ShowMeeting()
{
    Console.WriteLine($"{"Name",25}{"Start",25}{"End",25}{"Room",25}");
    foreach ((string name, DateTime start, int duration, string room) in meetings)
    {
        DateTime end = start.AddMinutes(duration);
        Console.WriteLine($"{name,25}{start,25}{end,25}{room,25}");
    }
}


void DumpToFile()
{
    StringBuilder sb = new();
    sb.AppendLine("Name,Start,Duration,Room");
    foreach ((string name, DateTime start, int duration, string room) in meetings)
    {
        sb.AppendLine($"{name},{start},{duration},{room}");
    }
    File.WriteAllText(filename,sb.ToString());
}

void LoadFromFile()
{
    if (!File.Exists(filename))
    {
        
    }
    string text = File.ReadAllText(filename);
    string[] lines = text.Split("\n");
    meetings = new (string,DateTime,int,string)[lines.Length-2];
    for (int i = 0; i < lines.Length-1; i++)
    {
        string line = lines[i];
        string[] items = line.Split(",");
        meetings[i-1] = (items[0],DateTime.Parse(items[1]),int.Parse(items[2]),items[3]);
    }
}

LoadFromFile();
while (true)
{
    Menu();
}