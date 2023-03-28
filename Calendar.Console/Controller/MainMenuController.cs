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
            WriteLine("Calendar");
            WriteLine();
            WriteLine("1. Create a meeting");
            WriteLine("2. Show all meetings");
            WriteLine("3. Update meeting");
            WriteLine("4. Show meetings by room");
            WriteLine("5. Show meetings by date range");
            WriteLine("0. Exit");
        }
        
        public IController Action()
        {
            ConsoleKeyInfo key = ReadKey();

            if (key.Key == ConsoleKey.D0)
            {
                return null;
            }
            if (key.Key == ConsoleKey.D1)
            {
                return new CreateMeetingController(_context);
            }
            if (key.Key == ConsoleKey.D2)
            {
                return new ShowAllMeetingsController(_context);
            }
            if (key.Key == ConsoleKey.D3)
            {
                Clear();
                return new UpdateMeetingController(_context);
            }
            if (key.Key == ConsoleKey.D4)
            {
                Clear();
                return new SelectMeetingsByRoomController(_context);
            }
            if (key.Key == ConsoleKey.D5)
            {
                return new CreateDateRangeController(_context);
            }

            return this;
        }
    }
}