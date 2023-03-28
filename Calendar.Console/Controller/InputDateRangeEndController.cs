using System;
using Calendar.Domain.Builders;

namespace Calendar.Console.Controllers
{
    internal class InputDateRangeEndController : IController
    {
        private readonly Context _context;
        private readonly DateRangeBuilder _dateRangeBuilder;

        public InputDateRangeEndController(Context context, DateRangeBuilder dateRangeBuilder)
        {
            _context = context;
            _dateRangeBuilder = dateRangeBuilder;
        }

        public void Show()
        {
            WriteLine("Enter meeting date end:");
        }
        
        public IController Action()
        {
            string input = ReadLine();

            if (!DateTime.TryParse(input, out DateTime end))
            {
                WriteLine("Date of meeting should be valid timestamp!");
                return this;
            }

            return new ShowMeetingsByDateRangeController(_context, _dateRangeBuilder.WithEnd(end));
        }
    }
}