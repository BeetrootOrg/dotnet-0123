using System;

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
            Clear();

            WriteLine("Calendar");
            WriteLine();
            WriteLine("1. Create a meeting");
            WriteLine("2. Show all meetings");
            WriteLine("3. Update existent meeting");
            WriteLine("0. Exit");
        }

        public IController Action()
        {
            ConsoleKeyInfo key = ReadKey();

            return key.Key == ConsoleKey.D0
                ? null
                : key.Key == ConsoleKey.D1
                ? new StartCreatingMeetingController(_context)
                : key.Key == ConsoleKey.D2
                ? new ShowAllMeetingsController(_context)
                : key.Key == ConsoleKey.D3
                ? new UpdateExistentMeetingController(_context)
                : this;
        }

    }
}