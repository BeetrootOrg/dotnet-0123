using Calendar.Domain;
using Calendar.Domain.Services;

namespace Calendar.Console
{
    internal class Context
    {
        public IMeetingService Service { get; }

        private Context(IMeetingService service)
        {
            Service = service;
        }

        public static Context CreateContext()
        {
            return new Context(Factory.CreateService());
        }
    }
}