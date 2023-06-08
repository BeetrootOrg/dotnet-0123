using System;

namespace ConsoleApp.Models
{
    internal class AppleGenerator
    {
        private readonly int _borderWidth;
        private readonly int _borderHeight;
        private readonly Snake _snake;
        public AppleGenerator(Border border, Snake snake)
        {
            if (border == null || snake == null)
            {
                throw new ArgumentException("Border or snake can't be null.");
            }

            _borderWidth = border.Width;
            _borderHeight = border.Height;
            _snake = snake;
        }
        public Apple Generate()
        {
            Random random = new(DateTime.Now.Millisecond);

            Apple apple = new(x: random.Next(0, _borderWidth), y: random.Next(0, _borderHeight));
            while (_snake.CheckWrongAppleGeneration(apple))
            {
                apple = new Apple(x: random.Next(0, _borderWidth), y: random.Next(0, _borderHeight));
            }

            return apple;
        }
    }
}