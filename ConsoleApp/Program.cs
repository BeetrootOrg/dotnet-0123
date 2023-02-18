using System.Text;
using System.Linq;
//------------------18.02.2023-------------------
// Homework ------- TEXT--------------------
//finish Calendar solution. Users should be able to:
//    update existent meeting by it’s name;
//    see meetings in certain room.

const string filename = "dump.csv";
(string, DateTime, int, string)[] meetings;

void Menu()
{
    Console.Clear();

    Console.WriteLine("Meeting Booker");
    Console.WriteLine();
    Console.WriteLine("1. Create a meeting");
    Console.WriteLine("2. Show all meetings");
    Console.WriteLine("3. Update existent meeting");
    Console.WriteLine("4. Show meeting in room");
    Console.WriteLine("0. Exit");

    ConsoleKeyInfo key = Console.ReadKey();
    if (key.Key == ConsoleKey.D0)
    {
        Exit();
    }
    else if (key.Key == ConsoleKey.D1)
    {
        CreateMeeting(null);
    }
    else if (key.Key == ConsoleKey.D2)
    {
        ShowMeetings();
    }
    else if (key.Key == ConsoleKey.D3)
    {
        UpdateExistingMeeting(string.Empty);
    }
    else if (key.Key == ConsoleKey.D4)
    {
        ShowMeetingInRoom();
    }
}

static void Exit()
{
    Environment.Exit(0);
}
//метод шукає всі записи по запиту який входе в назву, та дає змогу редагувати запис по індексу
// string s - строка пошука вертає користувоча на фільтровану сторінку
void UpdateExistingMeeting(string s)
{
    string input = s;
    Console.Clear();
    if (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("Enter meeting name to update, or press Enter to return:");
        input = Console.ReadLine();
    }
    if (string.IsNullOrEmpty(input)) return;
    var listmeets = meetings.Where(x => x.Item1.ToLower().Contains(input.ToLower())).ToArray();
    Console.WriteLine($"Found {listmeets.Length} meetings. Please select meeting to update, or return to Menu");
    Console.WriteLine("\t0. Return to Menu");
    int i = 1;
    foreach (var m in listmeets)
    {
        Console.WriteLine($"\t{i}. {m.Item1} {m.Item2} {m.Item3} {m.Item4}");
        i++;
    }
    int num;
    while (true)
    {
        string numstr = Console.ReadLine();
        if (int.TryParse(numstr, out num))
        {
            if (num > -1 && num <= listmeets.Length) break;
            else Console.WriteLine($"Number must be between 0..{listmeets.Length}");
        }
        else Console.WriteLine($"Please enter a number between 0..{listmeets.Length}");
    }
    if (num == 0) return;
    CreateMeeting(num - 1);
    UpdateExistingMeeting(input);
}
// Показує всі зустрічи в кімнаті
void ShowMeetingInRoom()
{
    Console.Clear();
    var m = meetings.Select(x => x.Item4).Distinct().Order().ToArray();
    Console.WriteLine("Please select number of room, or press Enter to return");
    int i = 0;
    foreach (var s in m)
    {
        Console.WriteLine($"{i}. {s}");
        i++;
    }
    int num;
    while (true)
    {
        string numstr = Console.ReadLine();
        if (string.IsNullOrEmpty(numstr)) return;
        if (int.TryParse(numstr, out num))
        {
            if (num > -1 && num < m.Length) break;
            else Console.WriteLine($"Number must be between 0..{m.Length}, or press Enter to return");
        }
        else Console.WriteLine($"Please enter a number between 0..{m.Length}, or press Enter to return");
    }
    ShowMeetings(m[num]);
}
// внесено зміну, int? index - індекс запису в масиві, якщо null - создається новий запис
void CreateMeeting(int? index = null)
{
    Console.Clear();

    string meetingName = EnterMeetingName();
    DateTime meetingStart = EnterMeetingStart();
    int meetingDuration = MeetingDurationInMinutes();
    (string, DateTime, int, string) meeting;
    bool itsnew = true;
    if (index != null && index >= 0 && index < meetings.Length)
    {
        meeting = meetings[(int)index];
        meeting.Item1 = meetingName;
        meeting.Item2 = meetingStart;
        meeting.Item3 = meetingDuration;
        itsnew = false;
    }
    else
    {
        string roomName = EnterRoomName();
        meeting = (meetingName, meetingStart, meetingDuration, roomName);
    }
    if (DoesIntersectWithOther(meeting))
    {
        Console.WriteLine("Meeting intersects with another!");
    }
    else
    {
        if (itsnew)
        {
            Array.Resize(ref meetings, meetings.Length + 1);
            meetings[^1] = meeting;
        }
        else meetings[(int)index] = meeting;
        DumpToFile();
        if (itsnew) Console.WriteLine("Meeting successfully created!");
        else Console.WriteLine("Meeting successfully updated!");
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
//Внесено зміни  Якщо параметр roomname не пустий відображаються зустрічі в обраній кімнаті
void ShowMeetings(string roomname = "")
{
    Console.Clear();
    Console.WriteLine($"{"Name",-25}{"Start",-25}{"End",-25}{"Room",-25}");
    if (!string.IsNullOrEmpty(roomname))
    {
        foreach ((string name, DateTime start, int duration, string room) in meetings.Where(x => x.Item4.Equals(roomname)).ToArray())
        {
            DateTime end = start.AddMinutes(duration);
            Console.WriteLine($"{name,-25}{start,-25}{end,-25}{room,-25}");
        }
    }
    else
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

    string text = File.ReadAllText(filename);

    string[] lines = text.Split('\n');
    meetings = new (string, DateTime, int, string)[lines.Length - 2];

    for (int i = 1; i < lines.Length - 1; i++)
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
