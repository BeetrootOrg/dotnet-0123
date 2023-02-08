Random random = new((int)DateTime.Now.Ticks);

Console.WriteLine("Press ENTER to start the game");
while (true)
{
    _ = Console.ReadLine();
    int num = random.Next(0, 6);
    if (num == 3)
    {
        Console.WriteLine("Game Over!");
        return;
    }
    else
    {
        Console.WriteLine("Continue game...");
    }
}