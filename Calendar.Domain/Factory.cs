using Calendar.Domain.Repositories;
using Calendar.Domain.Services;

namespace Calendar.Domain
{
    public static class Factory
    {
        public static IMeetingService CreateService()
        {
            return new MeetingService(new Repository());
        }
    }
}