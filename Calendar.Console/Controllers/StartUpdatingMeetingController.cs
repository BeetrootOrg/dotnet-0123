using System.Linq;

using Calendar.Domain.Builders;

namespace Calendar.Console.Controllers
{
    internal class StartUpdatingMeetingController : IController
    {
        private readonly Context _context;

        public StartUpdatingMeetingController(Context context)
        {
            _context = context;
        }

        public void Show()
        {
            Clear();
        }

        public IController Action()
        {
            if (_context.Service.GetAllMeetings().Any())
            {
                return new MeetingUpdateNameInputController(_context, new MeetingBuilder());
            }
            WriteLine("There are no meetings to update!");
            WriteLine("To continue press ENTER...");
            _ = ReadLine();

            return new MainMenuController(_context);
        }
    }
}