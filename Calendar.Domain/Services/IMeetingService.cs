using System.Collections.Generic;

using Calendar.Contracts;

namespace Calendar.Domain.Services
{
    public interface IMeetingService
    {
        IEnumerable<Meeting> GetAllMeetings();
        public bool IsAnyMeetingWithThisName(string searchName);
        void AddMeeting(Meeting meeting);
        void UpdateMeeting(Meeting meeting);
    }
}