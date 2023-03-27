using System;
using System.Collections.Generic;
using System.Linq;

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
            WriteLine("Enter the name of the room to be selected. Or leave it blank");
             IEnumerable<Meeting> meetings;
            string troom = ReadLine();
            if (string.IsNullOrEmpty(troom))
                meetings = _context.Service.GetAllMeetings();
            else
                meetings = _context.Service.GetAllMeetings().Where(x=>x.Room.Name.Equals(troom)).AsEnumerable();

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