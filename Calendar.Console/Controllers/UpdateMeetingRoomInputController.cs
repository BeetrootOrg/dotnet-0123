using Calendar.Contracts;
using Calendar.Domain.Builders;

namespace Calendar.Console.Controllers
{
    internal class UpdateMeetingRoomInputController : IController
    {
        private readonly Context _context;
        private readonly MeetingBuilder _meetingBuilder;

        public UpdateMeetingRoomInputController(Context context, MeetingBuilder meetingBuilder)
        {
            _context = context;
            _meetingBuilder = meetingBuilder;
        }

        public void Show()
        {
            WriteLine("Enter new room name:");
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

            return new UpdateMeetingController(_context, _meetingBuilder.WithRoom(room));
        }
    }
}