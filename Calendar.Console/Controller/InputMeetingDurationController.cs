using System;
using Calendar.Domain.Builders;

namespace Calendar.Console.Controllers
{
    internal class InputMeetingDurationController : IController
    {
        private readonly Context _context;
        private readonly MeetingBuilder _meetingBuilder;

        public InputMeetingDurationController(Context context, MeetingBuilder meetingBuilder)
        {
            _context = context;
            _meetingBuilder = meetingBuilder;
        }
        public void Show()
        {
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

            if (duration <= TimeSpan.Zero)
            {
                WriteLine("Meeting start should be positive");
                return this;
            }

            return new InputMeetingRoomController(_context, _meetingBuilder.WithDuration(duration));
        }
    }
}