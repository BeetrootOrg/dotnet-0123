using System;

namespace Calendar.Contracts
{
    public record DateRange
    {
        public DateTime Start { get; init; }
        public DateTime End { get; init; }
    }
}