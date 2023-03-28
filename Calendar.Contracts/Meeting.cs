using System;

namespace Calendar.Contracts
{
    public record Meeting
    {
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public TimeSpan Duration { get; set; }
        public Room Room { get; set; }

        public void Deconstruct(out string name, out DateTime start, out TimeSpan duration, out Room room)
        {
            name = Name;
            start = Start;
            duration = Duration;
            room = Room;
        }

        public Meeting Rewrite(Meeting meeting)
        {
            Name = meeting.Name;
            Start = meeting.Start;
            Duration = meeting.Duration;
            Room = meeting.Room;

            return this;
        }
    }
}