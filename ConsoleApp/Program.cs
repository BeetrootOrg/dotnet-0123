Random random = new((int)DateTime.Now.Ticks);
// for debugging console read in launch.json write "console": "externalTerminal"
System.Console.WriteLine("Press Enter to start");
while (true)
{
    Console.ReadLine();
    int num = random.Next(0,6);
    if (num == 3)
    {
        System.Console.WriteLine("You`ve killed");
        return;
    }
    else
    {
        System.Console.WriteLine("Continue");
    }
}