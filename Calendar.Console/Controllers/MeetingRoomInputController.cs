using System.Linq;

using Calendar.Contracts;
using Calendar.Domain.Builders;

namespace Calendar.Console.Controllers
{
    internal class MeetingRoomInputController : IController
    {
        private readonly Context _context;
        private readonly MeetingBuilder _meetingBuilder;
        private readonly Meeting _meeting;

        public MeetingRoomInputController(Context context, MeetingBuilder meetingBuilder, Meeting meeting = null)
        {
            _context = context;
            _meetingBuilder = meetingBuilder;
            _meeting = meeting;
        }

        public void Show()
        {
            if (_meeting != null)
            {
                WriteLine($"Meeting room name {_meeting.Room.Name}. Enter new room name:");
            }
            else
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

            if (_meeting != null)
            {
                var _room = _context.Service.GetAllMeetings().Select(x => x.Room).Where(x => x.Name.Equals(input)).FirstOrDefault();
                if (_room == null)
                {
                    _room = new()
                    {
                        Name = input
                    };
                }
                _meeting.Room= _room;
                return new UpdateMeetingController(_context, _meeting);
            }

            Room room = new()
            {
                Name = input
            };

            return new CreateMeetingController(_context, _meetingBuilder.WithRoom(room));
        }
    }
}