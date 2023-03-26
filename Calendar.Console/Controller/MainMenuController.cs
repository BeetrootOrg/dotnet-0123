using System;
using static System.Console;

namespace Calendar.Console.Controllers
{
    internal class MainMenuController : IController
    {
        private readonly Context _context;

        public MainMenuController(Context context)
        {
            _context = context;
        }

        public void Show()
        {
            WriteLine("Calendar");
            WriteLine();
            WriteLine("1. Create a meeting");
            WriteLine("2. Show all meetings");
            WriteLine("0. Exit");
        }
        
        public IController Action()
        {
            ConsoleKeyInfo key = ReadKey();

            if (key.Key == ConsoleKey.D0)
            {
                return null;
            }
            if (key.Key == ConsoleKey.D2)
            {
                return new ShowAllMeetingsController(_context);
            }

            return this;
        }
    }
}