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
}
static void Exit()
{
    Environment.Exit(0);
}
while(true)
{
    Menu();
}
