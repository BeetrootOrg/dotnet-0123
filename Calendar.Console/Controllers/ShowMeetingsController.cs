using System;
using System.Collections.Generic;
using System.Linq;

using Calendar.Contracts;

namespace Calendar.Console.Controllers
{
    internal class ShowMeetingsController : IController
    {
        private readonly Context _context;
        private readonly Room _room = null;

        public ShowMeetingsController(Context context)
        {
            _context = context;
        }

        public ShowMeetingsController(Context context, Room room) : this(context)
        {
            _room = room;
        }

        public void Show()
        {
            Clear();

            IEnumerable<Meeting> meetings;
            if (_room == null)
            {
                meetings = _context.Service.GetAllMeetings();
            }
            else
            {
                meetings = _context.Service.GetAllMeetings().Where(x => x.Room == _room);
            }

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