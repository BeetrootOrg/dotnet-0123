using System;
using static System.Console;
using Calendar.Contracts;

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
            foreach((string name, DateTime start, TimeSpan duration, Room room) in meetings)
            {
                DateTime end = start.Add(duration);
                WriteLine($"{name,-25}{start,-25}{end,-25}{room,-25}");
            }

            WriteLine();
            WriteLine("Press ENTER to continue...");
        }

        IController IController.Action()
        {
            ReadLine();
            return new MainMenuController(_context);
        }
    }
}