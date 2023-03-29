using Calendar.Domain.Builders;

namespace Calendar.Console.Controllers
{
    internal class StartCreatingMeetingController : IController
    {
        private readonly Context _context;

        public StartCreatingMeetingController(Context context)
        {
            _context = context;
        }

        public void Show()
        {
            Clear();
        }

        public IController Action()
        {
            return new MeetingNameInputController(_context, new MeetingBuilder());
        }
    }
}