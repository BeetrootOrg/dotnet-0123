using System;
using Calendar.Contracts;

namespace Calendar.Domain.Builders
{
    public class MeetingBuilder
    {
        private string _name;
        private DateTime _start; 
        private TimeSpan _duration; 
        private Room _room; 

        public MeetingBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public MeetingBuilder WithStart(DateTime start)
        {
            _start = start;
            return this;
        }

        public MeetingBuilder WithDuration(TimeSpan duration)
        {
            _duration = duration;
            return this;
        }

        public MeetingBuilder WithRoom(Room room)
        {
            _room = room;
            return this;
        }

        public Meeting Build()
        {
            return new Meeting
            {
                Name = _name,
                Start = _start,
                Duration = _duration,
                Room = _room
            };     
        }
    }
}