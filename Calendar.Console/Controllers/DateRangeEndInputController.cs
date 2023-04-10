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
            Clear();
            WriteLine("Enter date range end:");
        }
        public IController Action()
        {
            string input = ReadLine();

            if (!DateTime.TryParse(input, out DateTime end))
            {
                WriteLine("Meeting duration should be valid timespan!");
                return this;
            }

            return new ShowAllMeetingsByDateRangeController(_context, _startDateRange, end);
        }
    }
}