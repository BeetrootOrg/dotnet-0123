void Menu()
{
    Console.Clear();

    Console.WriteLine("Meeting booker");
    Console.WriteLine("");
    Console.WriteLine("1, Create a meeting");
    Console.WriteLine("0, Exit");

    var key = Console.ReadKey();
    if (key.Key == ConsoleKey.D0)
    {
        Exit();
    }
}

static void Exit()
{
    Environment.Exit(0);
}

while (true)
{
    Menu();
}