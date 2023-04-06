using System;
using System.Collections.Generic;
using System.Linq;

using ConsoleApp.Enums;
using ConsoleApp.Exceptions;

namespace ConsoleApp.Models
{
    internal class AppleGenerator
    {
        private int _borderWidth;
        private int _borderHeight;
        private Snake _snake;
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
            Random random = new Random(DateTime.Now.Millisecond);

            Apple apple = new Apple(x: random.Next(0, _borderWidth), y: random.Next(0, _borderHeight));
            while (_snake.CheckWrongAppleGeneration(apple))
            {
                apple = new Apple(x: random.Next(0, _borderWidth), y: random.Next(0, _borderHeight));
            }

            return apple;
        }
    }
}