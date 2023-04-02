using System.Collections.Generic;

using Calendar.Contracts;

namespace Calendar.Domain.Repositories
{
    internal interface IRepository
    {
        IEnumerable<Meeting> GetAllMeetings();
        void AddMeeting(Meeting meeting);
        void UpdateMeeting(Meeting updatedMeeting);
    }
}