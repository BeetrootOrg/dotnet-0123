using Calendar.Contracts;

using System.Linq;

namespace Calendar.Console.Controllers
{
    internal class MeetingsByRoomInputController : IController
    {
        private readonly Context _context;

        public MeetingsByRoomInputController(Context context)
        {
            _context = context;
        }

        public void Show()
        {
            Clear();

            WriteLine("Enter room name:");
        }

        public IController Action()
        {
            Room room = new Room
            {
                Name = ReadLine()
            };

            if (!_context.Service.GetAllMeetings().Any(x => x.Room == room))
            {
                WriteLine($"There is no meetings in room {room.Name}");

                WriteLine();
                WriteLine("To continue press ENTER...");
                _ = ReadLine();

                return new MainMenuController(_context);
            }

            return new ShowMeetingsController(_context, room);
        }
    }
}