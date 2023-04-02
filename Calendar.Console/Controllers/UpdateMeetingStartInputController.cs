using System;

using Calendar.Domain.Builders;

namespace Calendar.Console.Controllers
{
    internal class UpdateMeetingStartInputController : IController
    {
        private readonly Context _context;
        private readonly MeetingBuilder _meetingBuilder;

        public UpdateMeetingStartInputController(Context context, MeetingBuilder meetingBuilder)
        {
            _context = context;
            _meetingBuilder = meetingBuilder;
        }

        public void Show()
        {
            WriteLine("Enter new meeting start:");
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

            return new UpdateMeetingDurationInputController(_context, _meetingBuilder.WithStart(start));
        }
    }
}