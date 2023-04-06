using System;

using ConsoleApp.Enums;
using ConsoleApp.Exceptions;

namespace ConsoleApp.Models.Objects
{
    internal class SnakeObject : IGameObject
    {
        public char Symbol => '#';
        public int X { get; init; }
        public int Y { get; init; }
        public SnakeObject(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Render()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }

        public SnakeObject Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (this.Y == 0)
                    {
                        throw new OutOfConsoleRangeException("The snake can't be printed outside of console.");
                    }
                    return new SnakeObject(this.X, this.Y - 1);
                case Direction.Right:
                    return new SnakeObject(this.X + 1, this.Y);
                case Direction.Down:
                    return new SnakeObject(this.X, this.Y + 1);
                case Direction.Left:
                    if (this.X == 0)
                    {
                        throw new OutOfConsoleRangeException("The snake can't be printed outside of console.");
                    }
                    return new SnakeObject(this.X - 1, this.Y);
            }
            return null;
        }
    }
}