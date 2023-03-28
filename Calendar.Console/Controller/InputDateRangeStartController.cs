using System;
using Calendar.Domain.Builders;

namespace Calendar.Console.Controllers
{
    internal class InputDateRangeStartController : IController
    {
        private readonly Context _context;
        private readonly DateRangeBuilder _dateRangeBuilder;

        public InputDateRangeStartController(Context context, DateRangeBuilder dateRangeBuilder)
        {
            _context = context;
            _dateRangeBuilder = dateRangeBuilder;
        }

        public void Show()
        {
            WriteLine("Enter meeting date start:");
        }
        
        public IController Action()
        {
            string input = ReadLine();

            if (!DateTime.TryParse(input, out DateTime start))
            {
                WriteLine("Date of meeting should be valid timestamp!");
                return this;
            }

            return new InputDateRangeEndController(_context, _dateRangeBuilder.WithStart(start));
        }
    }
}