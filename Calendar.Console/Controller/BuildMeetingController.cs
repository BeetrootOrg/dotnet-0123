using Calendar.Contracts;
using Calendar.Domain.Builders;

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
            _context.Repository.AddMeeting(meeting);

            return new MainMenuController(_context);
        }
    }
}