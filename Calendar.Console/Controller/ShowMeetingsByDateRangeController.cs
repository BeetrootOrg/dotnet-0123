using System;
using System.Collections.Generic;
using System.Linq;
using Calendar.Contracts;
using Calendar.Domain.Builders;

namespace Calendar.Console.Controllers
{
    internal class ShowMeetingsByDateRangeController : IController
    {
        private readonly Context _context;
        private readonly DateRangeBuilder _dateRangeBuilder;

        public ShowMeetingsByDateRangeController(Context context, DateRangeBuilder dateRangeBuilder)
        {
            _context = context;
            _dateRangeBuilder = dateRangeBuilder;
        }
        
        public void Show()
        {
            DateRange dateRange = _dateRangeBuilder.Build();
            Clear();

            IEnumerable<Meeting> meetings = _context.Service.GetAllMeetings()
                .Where(m => m.Start >= dateRange.Start && m.Start.Add(m.Duration) <= dateRange.End);

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
            ReadLine();
            return new MainMenuController(_context);
        }
    }
}