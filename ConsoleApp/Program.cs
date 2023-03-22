using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

using static System.Console;
namespace SnakeGame
{
    public class Program
    {
       private const int MapWidth = 60;
       private const int MapHeigth = 30;
       private const int FrameNs = 200;
       private const ConsoleColor BorderColor = ConsoleColor.Gray;
       private const ConsoleColor HeadColor = ConsoleColor.DarkGreen;
       private const ConsoleColor BodyColor = ConsoleColor.Green;
       private const ConsoleColor FoodColor = ConsoleColor.Red;
       private static readonly Random random = new Random();

       static void Main()
       {
            Clear();
            CursorVisible = false;

            while (true)
            {
                StartGame();

                Thread.Sleep(1000);

            	ReadKey();
            }
       }

       static void StartGame()
       {
            Clear();

            DrawBorder();

            Direction currentMovement = Direction.Rigth;

            var snake = new Snake(10, 5, HeadColor, BodyColor);

            Pixel food = GenFood(snake);
            food.Draw();

            int score = 0;

            int lagMS =0;

            var sw = new Stopwatch();

            while (true)
            {
                sw.Restart();

                while (sw.ElapsedMilliseconds <= FrameNs - lagMS)
                {
                    currentMovement = ReadMovement(currentMovement);
                }

                sw.Restart();

                if(snake.Head.X == food.X && snake.Head.Y == food.Y)
                {
                    snake.Move(currentMovement, true);

                    food = GenFood(snake);
                    food.Draw();

                    score++;
                }
                else
                {
                    snake.Move(currentMovement);
                }

                if(snake.Head.X == MapWidth - 1 
                || snake.Head.X == 0 
                || snake.Head.Y == MapHeigth - 1 
                || snake.Head.Y == 0
                || snake.Body.Any(b => b.X == snake.Head.X && b.Y == snake.Head.Y))
                break;

                lagMS = (int)sw.ElapsedMilliseconds;
            }

            snake.Clear();
          
            SetCursorPosition(MapWidth / 3, MapHeigth / 2);

            WriteLine($"Game over, score {score}");
        }
        
        static Pixel GenFood(Snake snake)
        {
            Pixel food;

            do
            {
                food = new Pixel(random.Next(1, MapWidth - 2), random.Next(1, MapHeigth - 2), FoodColor);
            } 
            while (snake.Head.X == food.X && snake.Head.Y == food.Y
                   || snake.Body.Any(b => b.X == food.X && b.Y == food.Y));

            return food;       
        }

        static Direction ReadMovement(Direction currentDirection)
        {
            if (!KeyAvailable)
                return currentDirection;

            ConsoleKey key = ReadKey(true).Key;

            currentDirection = key switch 
            {
                ConsoleKey.UpArrow when currentDirection != Direction.Down => Direction.Up,
                ConsoleKey.DownArrow when currentDirection != Direction.Up => Direction.Down,
                ConsoleKey.LeftArrow when currentDirection != Direction.Rigth => Direction.Left,
                ConsoleKey.RightArrow when currentDirection != Direction.Left => Direction.Rigth,
                _ => currentDirection,
            };   
            
            return currentDirection;
        }

        static void DrawBorder()
        {
            for(int i = 0; i < MapWidth; i++)
            {
                new Pixel (i, 0, BorderColor).Draw();
                new Pixel (i, MapHeigth - 1, BorderColor).Draw();
            }

            for(int i = 0; i < MapHeigth; i++)
            {
                new Pixel (0, i, BorderColor).Draw();
                new Pixel (MapWidth - 1, i, BorderColor).Draw();
            }
        }
    }
}