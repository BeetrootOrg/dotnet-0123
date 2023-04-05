namespace Calendar.Console.Controllers
{
    internal class ShowMeetingEnterRoomNameController : IController
    {
        private readonly Context _context;

        public ShowMeetingEnterRoomNameController(Context context)
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
            return new ShowMeetingsByRoomController(_context, input);
        }
    }
}