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

        public static Context CreateContext(string filename)
        {
            return new Context(Factory.CreateService(filename));
        }
    }
}