using Calendar.Domain.Builders;

namespace Calendar.Console.Controllers
{
    internal class CreateMeetingController : IController
    {
        private readonly Context _context;

        public CreateMeetingController(Context context)
        {
            _context = context;
        }

        public void Show()
        {
            Clear();
        }
        public IController Action()
        {
            return new InputMeetingNameController(_context, new MeetingBuilder()); 
        }
    }
}