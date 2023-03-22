using System.Collections.Generic;

using Calendar.Contracts;

namespace Calendar.Domain.Repositories
{
    internal class Repository : IRepository
    {
        private readonly IList<Meeting> _meetings;

        public Repository()
        {
            _meetings = new List<Meeting>();
        }

        public void AddMeeting(Meeting meeting)
        {
            _meetings.Add(meeting);
        }

        public IEnumerable<Meeting> GetAllMeetings()
        {
            return _meetings;
        }
    }
}