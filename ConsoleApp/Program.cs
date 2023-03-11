static void Menu()
{
    Console.Clear();

    Console.WriteLine("Meeting Booker");
    Console.WriteLine();
    Console.WriteLine("1.Create meeting");
    Console.WriteLine("0.Exit");

    var key = Console.ReadKey();
    if(key.Key == ConsoleKey.D0)
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

    System.Console.WriteLine("Enter Meeting Name:");
    string meetingName = Console.ReadLine();

    System.Console.WriteLine("Enter Meeting start:");
    string meetingStartInput = Console.ReadLine();
    DateTime meetingStart = DateTime.Parse(meetingStartInput);

    System.Console.WriteLine("Enter meeting duration");
    string meetingDurationInput = Console.ReadLine();
    int meetingDuration = int.Parse(meetingDurationInput);
    
    System.Console.WriteLine("Room Name");
    string roomName = Console.ReadLine();

System.Console.WriteLine($"{meetingName}{meetingStart}{meetingDuration}{roomName}");


}
while(true)
{
    Menu();
}
