using System;

namespace Calendar.Console.Controllers
{
    internal class DateRangeStartInputController : IController
    {
        private readonly Context _context;

        public DateRangeStartInputController(Context context)
        {
            _context = context;
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

            return new DateRangeEndInputController(_context, start);
        }
    }
}