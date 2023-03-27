using Calendar.Contracts;
using Calendar.Domain.Builders;

namespace Calendar.Console.Controllers
{
    internal class InputMeetingRoomController : IController
    {
        private readonly Context _context;
        private readonly MeetingBuilder _meetingBuilder;

        public InputMeetingRoomController(Context context, MeetingBuilder meetingBuilder)
        {
            _context = context;
            _meetingBuilder = meetingBuilder;
        }

        public void Show()
        {
            WriteLine("Enter room name:");
        }
        
        public IController Action()
        {
            string input = ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                WriteLine("Meeting room should be not empty");
                return this;
            }

            if (input.Length > 20)
            {
                WriteLine("Meeting room length should be less than 20");
                return this;
            }

            Room room = new Room
            {
                Name = input 
            };

            return new BuildMeetingController(_context, _meetingBuilder.WithRoom(room));
        }
    }
}