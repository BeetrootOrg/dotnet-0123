using System.Collections.Generic;

using Calendar.Contracts;

namespace Calendar.Console.Controllers
{
    internal class ShowMeetingsByRoomController : BaseShowMeetingsByRoom
    {
        private readonly string _roomName;

        public ShowMeetingsByRoomController(Context context, string roomName) : base(context)
        {
            _roomName = roomName;
        }

        protected override IEnumerable<Meeting> GetMeetings()
        {
            return _context.Service.GetMeetingsByRoomName(_roomName);
        }
    }
}