using System;

namespace Calendar.Contracts
{
    public record Meeting
    {
        public string Name { get; init; }
        public DateTime Start { get; init; }
        public TimeSpan Duration { get; init; }
        public Room Room { get; init; }

        public void Deconstruct(out string name, out DateTime start, out TimeSpan duration, out Room room)
        {
            name = Name;
            start = Start;
            duration = Duration;
            room = Room;
        }
    }
}