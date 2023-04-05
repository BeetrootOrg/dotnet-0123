using System.Collections.Generic;

using Calendar.Contracts;

namespace Calendar.Domain.Services
{
    public interface IMeetingService
    {
        IEnumerable<Meeting> GetAllMeetings();
        IEnumerable<Meeting> GetMeetingsByRoomName(string roomName);
        void AddMeeting(Meeting meeting);
    }
}