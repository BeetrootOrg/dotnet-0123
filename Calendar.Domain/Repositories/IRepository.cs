using System.Collections.Generic;

using Calendar.Contracts;

namespace Calendar.Domain.Repositories
{
    internal interface IRepository
    {
        IEnumerable<Meeting> GetAllMeetings();
        IEnumerable<Meeting> GetMeetingsByRoomName(string roomName);
        void AddMeeting(Meeting meeting);
    }
}