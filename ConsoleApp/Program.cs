using ConsoleApp;

using System;
using System.Threading;

SnakeGame game = new SnakeGame(10, 10);
Timer timer = new((state) => game.Update(), null, TimeSpan.Zero, TimeSpan.FromMilliseconds(game.Speed));
while (true)
{
    game.Listen();

}