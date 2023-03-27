using System;

using Calendar.Contracts;
using Calendar.Domain.Builders;

namespace Calendar.Console.Controllers
{
    internal class MeetingStartInputController : IController
    {
        private readonly Context _context;
        private readonly MeetingBuilder _meetingBuilder;
        private readonly Meeting _meeting;

        public MeetingStartInputController(Context context, MeetingBuilder meetingBuilder, Meeting meeting = null)
        {
            _context = context;
            _meetingBuilder = meetingBuilder;
            _meeting = meeting;
        }

        public void Show()
        {
            if (_meeting != null)
            {
                WriteLine($"Meeting start {_meeting.Start}. Enter new start:");
            }
            else
                WriteLine("Enter meeting start:");
        }

        public IController Action()
        {
            string input = ReadLine();
            if (!DateTime.TryParse(input, out DateTime start))
            {
                WriteLine("Meeting start should be valid timestamp!");
                return this;
            }

            if (start <= DateTime.Now)
            {
                WriteLine("Meeting start should be in future!");
                return this;
            }
            if (_meeting != null) _meeting.Start = start;
            return new MeetingDurationInputController(_context, _meetingBuilder.WithStart(start), _meeting);
        }
    }
}