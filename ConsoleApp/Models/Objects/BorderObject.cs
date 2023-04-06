using System;

namespace ConsoleApp.Models.Objects
{
    internal class BorderObject : IGameObject
    {
        public char Symbol => '@';
        public int X { get; init; }
        public int Y { get; init; }
        public BorderObject(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Render()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }
    }
}