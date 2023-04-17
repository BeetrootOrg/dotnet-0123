using System;

namespace Calendar.Console.Controllers
{
    internal class SearchByDateRangeMeetingController : IController
    {
        private readonly Context _context;
        public SearchByDateRangeMeetingController(Context context)
        {
            _context = context;
        }
        public void Show()
        {
            Clear();
            WriteLine("Enter date range start:");
        }
        public IController Action()
        {
            string input = ReadLine();

            if (!DateTime.TryParse(input, out DateTime start))
            {
                WriteLine("Meeting duration should be valid timespan!");
                return this;
            }

            return new DateRangeEndInputController(_context, start);
        }
    }
}