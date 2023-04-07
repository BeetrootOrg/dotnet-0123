using System;

namespace ConsoleApp.Models.Objects
{
    internal class AppleObject : IGameObject
    {
        public char Symbol => '○';
        public int X { get; init; }
        public int Y { get; init; }
        public AppleObject(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Render()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
            Console.ResetColor();
        }
    }
}