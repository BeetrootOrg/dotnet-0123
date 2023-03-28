using System.Collections.Generic;

using Calendar.Contracts;

namespace Calendar.Domain.Services
{
    public interface IMeetingService
    {
        IEnumerable<Meeting> GetAllMeetings();
        void AddMeeting(Meeting meeting);
        void UpdateMeeting(Meeting meeting, string oldName);
        void SetBuffer(string buffer);
        string GetBuffer();
    }
}
