using Calendar.Contracts;
using Calendar.Domain.Builders;
using Calendar.Domain.Exceptions;

namespace Calendar.Console.Controllers
{
    internal class BuildMeetingController : IController
    {
        private readonly Context _context;
        private readonly MeetingBuilder _meetingBuilder;

        public BuildMeetingController(Context context, MeetingBuilder meetingBuilder)
        {
            _context = context;
            _meetingBuilder = meetingBuilder;
        }
        public void Show()
        {
        }

        public IController Action()
        {
            Meeting meeting = _meetingBuilder.Build();

            try
            {
                _context.Service.AddMeeting(meeting);
                WriteLine("Meeting successfully created!");
            }
            catch (CalendarException ce)
            {
                WriteLine(ce.Message);
            }

            WriteLine("To continue press ENTER...");
            _ = ReadLine();

            return new MainMenuController(_context);
        }
    }
}