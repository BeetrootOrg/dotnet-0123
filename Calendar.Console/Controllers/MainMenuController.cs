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
            WriteLine("3. Update meeting");
            WriteLine("4. See meetings by room");
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
                ? new ShowMeetingsController(_context)
                : key.Key == ConsoleKey.D3
                ? new StartUpdatingMeetingController(_context)
                : key.Key == ConsoleKey.D4
                ? new MeetingsByRoomInputController(_context)
                : this;
        }

    }
}