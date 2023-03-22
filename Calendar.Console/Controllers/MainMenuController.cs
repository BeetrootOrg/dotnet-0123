using System;

using static System.Console;

namespace Calendar.Console.Controllers
{
    internal class MainMenuController : IController
    {
        public void Show()
        {
            Clear();

            WriteLine("Calendar");
            WriteLine();
            WriteLine("1. Create a meeting");
            WriteLine("2. Show all meetings");
            WriteLine("0. Exit");
        }

        public IController Action()
        {
            ConsoleKeyInfo key = ReadKey();

            return key.Key == ConsoleKey.D0
                ? (IController)null
                : this;
        }

    }
}