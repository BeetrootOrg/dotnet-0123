using System;
using System.Collections.Generic;

using Calendar.Contracts;

namespace Calendar.Console.Controllers
{
    internal class ShowMeetingsByDateRange : IController
    {
        private readonly Context _context;
        private readonly DateTime _startRange;
        private readonly DateTime _endRange;

        public ShowMeetingsByDateRange(Context context, DateTime startRange, DateTime endRange)
        {
            _context = context;
            _startRange = startRange > endRange ? endRange : startRange;
            _endRange = endRange > startRange ? endRange : startRange;
        }

        public void Show()
        {
            Clear();

            IEnumerable<Meeting> meetings = _context.Service.GetAllMeetings();

            WriteLine($"{"Name",-25}{"Start",-25}{"End",-25}{"Room",-25}");
            foreach ((string name, DateTime start, TimeSpan duration, Room room) in meetings)
            {
                DateTime end = start.Add(duration);
                if ((_startRange <= end) && (_endRange >= end))
                {
                    WriteLine($"{name,-25}{start,-25}{end,-25}{room.Name,-25}");
                }

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