using System;

using Calendar.Contracts;
using Calendar.Domain.Builders;

namespace Calendar.Console.Controllers
{
    internal class MeetingDurationInputController : IController
    {
        private readonly Context _context;
        private readonly MeetingBuilder _meetingBuilder;
        private readonly Meeting _meeting;

        public MeetingDurationInputController(Context context, MeetingBuilder meetingBuilder, Meeting meeting = null)
        {
            _context = context;
            _meetingBuilder = meetingBuilder;
            _meeting = meeting;
        }

        public void Show()
        {
            if (_meeting != null)
            {
                WriteLine($"Meeting duration {_meeting.Duration}. Enter new duration:");
            } else
            WriteLine("Enter meeting duration:");
        }

        public IController Action()
        {
            string input = ReadLine();
            if (!TimeSpan.TryParse(input, out TimeSpan duration))
            {
                WriteLine("Meeting duration should be valid timespan!");
                return this;
            }

            if (duration < TimeSpan.Zero)
            {
                WriteLine("Meeting duration should be positive!");
                return this;
            }
            if (_meeting != null) _meeting.Duration = duration;
            return new MeetingRoomInputController(_context, _meetingBuilder.WithDuration(duration),_meeting);
        }
    }
}