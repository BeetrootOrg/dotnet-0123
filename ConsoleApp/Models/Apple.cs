using System;

using ConsoleApp.Models.Objects;

namespace ConsoleApp.Models
{
    internal class Apple
    {
        public int X => _appleObject.X;
        public int Y => _appleObject.Y;
        private AppleObject _appleObject;
        public Apple(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                throw new ArgumentException("Apple can't be generated outside the bounds of console.");
            }

            _appleObject = new AppleObject(x, y);
        }

        public void Render()
        {
            Console.SetCursorPosition(_appleObject.X, _appleObject.Y);
            Console.Write(_appleObject.Symbol);
        }
    }
}