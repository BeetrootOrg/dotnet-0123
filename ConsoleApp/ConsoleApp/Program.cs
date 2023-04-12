using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Snake Game";
            Console.CursorVisible = false;

            Snake snake = new Snake();
            Food food = new Food();

            while (true)
            {
                snake.Move();
                if (snake.HitWall())
                {
                    Console.Clear();
                    Console.WriteLine("Game Over! You hit the wall!");
                    Console.ReadKey();
                    break;
                }

                if (snake.HitBody())
                {
                    Console.Clear();
                    Console.WriteLine("Game Over! You hit yourself!");
                    Console.ReadKey();
                    break;
                }

                if (snake.Eat(food))
                {
                    food.Generate();
                }

                Console.Clear();
                snake.Draw();
                food.Draw();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.ChangeDirection(key);
                }

                Thread.Sleep(100);
            }
        }
    }
    
    
}
        