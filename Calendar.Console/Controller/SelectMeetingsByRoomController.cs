namespace Calendar.Console.Controllers
{
    internal class SelectMeetingsByRoomController : IController
    {
        private readonly Context _context;

        public SelectMeetingsByRoomController(Context context)
        {
            _context = context;
        }

        public void Show()
        {
            WriteLine("Enter room for select:");
        }

        public IController Action()
        {
            string input = ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                WriteLine("Room name should be not empty");
                return this;
            }

            return new ShowMeetingsByRoomController(_context, input);
        }
    }
}