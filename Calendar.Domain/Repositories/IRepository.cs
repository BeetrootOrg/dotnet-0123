using System.Collections.Generic;

using Calendar.Contracts;

namespace Calendar.Domain.Repositories
{
    public interface IRepository
    {
        IEnumerable<Meeting> GetAllMeetings();
    }
}