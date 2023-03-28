using System;
using Calendar.Contracts;

namespace Calendar.Domain.Builders
{
    public class DateRangeBuilder
    {
        private DateTime _start; 
        private DateTime _end; 

        public DateRangeBuilder WithStart(DateTime start)
        {
            _start = start;
            return this;
        }
        public DateRangeBuilder WithEnd(DateTime end)
        {
            _end = end;
            return this;
        }

        public DateRange Build()
        {
            return new DateRange
            {
                Start = _start,
                End = _end
            };     
        }
    }
}