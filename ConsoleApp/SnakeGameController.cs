using System;

using ConsoleApp.Enums;
using ConsoleApp.Exceptions;
using ConsoleApp.Models;

namespace ConsoleApp
{
    internal class SnakeGameController
    {
        private Snake _snake;
        private AppleGenerator _appleGenerator;
        private Apple _currentApple;
        private Border _border;
        private int _maxSnakeLength;

        public GameState GameState { get; private set; } = GameState.Playing;
        public SnakeGameController(Snake snake, AppleGenerator appleGenerator, Border border)
        {
            if (snake is null)
            {
                throw new ArgumentNullException(nameof(snake));
            }

            if (appleGenerator is null)
            {
                throw new ArgumentNullException(nameof(appleGenerator));
            }

            if (border is null)
            {
                throw new ArgumentNullException(nameof(border));
            }

            _snake = snake;
            _maxSnakeLength = border.Height * border.Width;
            _appleGenerator = appleGenerator;
            _currentApple = _appleGenerator.Generate();
            _border = border;
        }

        public void Step(Direction direction)
        {
            Console.SetCursorPosition(0, _border.Height + 1);
            Console.WriteLine($"SCORE: {_snake.Score}\nSNAKE LENGTH: {_snake.Length}\n");

            try
            {
                if (_snake.Update(direction, _currentApple))
                {
                    _currentApple = _appleGenerator.Generate();
                }
            }
            catch (OutOfConsoleRangeException)
            {
                GameState = GameState.GameOver;
            }

            _snake.Render();
            _currentApple.Render();
            _border.Render();

            Check();
        }
        private void Check()
        {
            if (_snake.Length == _maxSnakeLength)
            {
                GameState = GameState.Win;
            }
            else if (_border.TouchCheck(_snake.Head) || _snake.IsHitted())
            {
                GameState = GameState.GameOver;
            }
        }
    }
}