using SnakeGame.ConsoleView;
using System.Threading;

// Y = Console.WindowHeight;
// X = Console.WindowWidth;

ConsoleView game = new ConsoleView();

// this command create body with 3 parts
// game.Test();
Timer timer = new((state) => game.Render(), null, TimeSpan.Zero, TimeSpan.FromSeconds(game.GameSpeed));
while (true)
{
    game.Action();
}






