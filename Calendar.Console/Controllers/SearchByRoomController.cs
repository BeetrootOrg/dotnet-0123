using Calendar.Contracts;

namespace Calendar.Console.Controllers
{
    internal class SearchByRoomController : IController
    {
        private readonly Context _context;

        public SearchByRoomController(Context context)
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
            string input = ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                WriteLine("Room name should be not empty!");
                return this;
            }

            if (input.Length > 20)
            {
                WriteLine("Room name length should be less than 20!");
                return this;
            }

            Room room = new()
            {
                Name = input
            };

            return new ShowMeetingsByRoom(_context, room);
        }
    }
}