using System;
using System.Threading;

using ConsoleApp.Enums;
using ConsoleApp.Models;

namespace ConsoleApp
{
    internal class SnakeGame
    {
        private const Direction INITIAL_DIRECTION = Direction.Right;

        private SnakeGameController _controller;
        private Direction _direction = INITIAL_DIRECTION;
        private AppleGenerator _appleGenerator;
        private Border _border;
        private Snake _snake;

        public double Speed { get; } = 500;
        public GameState State => _controller.GameState;

        public SnakeGame(int width, int height)
        {
            Console.CursorVisible = false;

            _border = new Border(width, height);
            _snake = new Snake(_border);
            _appleGenerator = new AppleGenerator(_border, _snake);

            _controller = new SnakeGameController(_snake, _appleGenerator, _border);
        }
        public SnakeGame(int width, int height, int updateSpeed) : this(width, height)
        {
            if (updateSpeed < 50)
            {
                throw new ArgumentException("Max update speed is 50 milliseconds.");
            }
        }

        public void Update()
        {
            Console.Clear();
            if (State == GameState.Playing)
            {
                _controller.Step(_direction);
            }
            if (State == GameState.Win)
            {
                Console.Clear();
                Console.WriteLine($"Congratulations, you won! (Press any key)");
            }
            if (State == GameState.GameOver)
            {
                Console.Clear();
                Console.WriteLine($"You lose! (Press any key)");
            }
        }

        public void Listen()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    _direction = Direction.Up;
                    break;
                case ConsoleKey.RightArrow:
                    _direction = Direction.Right;
                    break;
                case ConsoleKey.DownArrow:
                    _direction = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    _direction = Direction.Left;
                    break;
            }
        }
    }
}