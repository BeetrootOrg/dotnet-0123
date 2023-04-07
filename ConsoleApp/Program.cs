using ConsoleApp;
using ConsoleApp.Enums;

using System;
using System.Threading;

int width = 0;
int height = 0;
bool isValid = false;
while (!isValid)
{
    Console.Write("Please enter the width of field [5-50] (recommendated is 10): ");
    if (!int.TryParse(Console.ReadLine(), out width) || width < 5 || width > 50)
    {
        Console.Clear();
        continue;
    }
    Console.Write("Enter the height of field [5-50] (recommendated is 10) and BE READY: ");
    if (!int.TryParse(Console.ReadLine(), out height) || height < 5 || height > 50)
    {
        Console.Clear();
        continue;
    }
    isValid = true;
}

do
{
    Console.Clear();
    SnakeGame game = new SnakeGame(width, height);

    Timer timer = new((_) => { game.Update(); }, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(game.Speed));

    while (game.State == GameState.Playing)
    {
        game.Listen();
    }

    timer.Change(Timeout.Infinite, Timeout.Infinite);

    Console.SetCursorPosition(0, 2);
    Console.WriteLine("To restart the game press any key \nTo close press SPACE BAR");

}
while (Console.ReadKey().Key != ConsoleKey.Spacebar);

