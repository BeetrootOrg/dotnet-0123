using Calendar.Domain.Repositories;

namespace Calendar.Domain
{
    public static class Factory
    {
        public static IRepository CreateRepository()
        {
            return new Repository();
        }
    }
}