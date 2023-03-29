using Calendar.Domain.Repositories;
using Calendar.Domain.Services;

namespace Calendar.Domain
{
    public static class Factory
    {
        public static IMeetingService CreateService(string filename)
        {
            return new MeetingService(Repository.CreateRepository(filename));
        }
    }
}