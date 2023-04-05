using System;
using System.Collections.Generic;

using Calendar.Contracts;

namespace Calendar.Console.Controllers
{
    internal abstract class BaseShowMeetingsByRoom : IController
    {
        protected readonly Context _context;

        protected BaseShowMeetingsByRoom(Context context)
        {
            _context = context;
        }

        public void Show()
        {
            Clear();

            IEnumerable<Meeting> meetings = GetMeetings();

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

        protected abstract IEnumerable<Meeting> GetMeetings();
    }
}