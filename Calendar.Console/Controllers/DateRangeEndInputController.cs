using System;

namespace Calendar.Console.Controllers
{
    internal class DateRangeEndInputController : IController
    {
        private readonly Context _context;
        private readonly DateTime _startDateRange;

        public DateRangeEndInputController(Context context, DateTime startDateRange)
        {
            _context = context;
            _startDateRange = startDateRange;
        }

        public void Show()
        {
            WriteLine("Enter date range start:");
        }

        public IController Action()
        {
            string input = ReadLine();
            if (!DateTime.TryParse(input, out DateTime start))
            {
                WriteLine("Meeting start should be valid timestamp!");
                return this;
            }

            return new ShowMeetingsByDateRange(_context, _startDateRange, start);
        }
    }
}