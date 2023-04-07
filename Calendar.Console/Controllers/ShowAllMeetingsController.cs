using System;

using Calendar.Contracts;

using static System.Console;

namespace Calendar.Console.Controllers
{
    internal class ShowAllMeetingsController : IController
    {
        private readonly Context _context;

        public ShowAllMeetingsController(Context context)
        {
            _context = context;
        }

        public void Show()
        {
            Clear();

            var meetings = _context.Repository.GetAllMeetings();

            WriteLine($"{"Name",-25}{"Start",-25}{"End",-25}{"Room",-25}");
            foreach ((string name, DateTime start, TimeSpan duration, Room room) in meetings)
            {
                DateTime end = start.Add(duration);
                WriteLine($"{name,-25}{start,-25}{end,-25}{room.Name,-25}");
            }

            WriteLine();
            WriteLine("To continue press ENTER...");
        }

        public IController Action()
        {
            _ = ReadLine();
            return new MainMenuController(_context);
        }
    }
}