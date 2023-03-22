using Calendar.Domain;
using Calendar.Domain.Repositories;

namespace Calendar.Console
{
    internal class Context
    {
        public IRepository Repository { get; }

        private Context(IRepository repository)
        {
            Repository = repository;
        }

        public static Context CreateContext()
        {
            return new Context(Factory.CreateRepository());
        }
    }
}