using Calendar.Domain.Builders;

namespace Calendar.Console.Controllers
{
    internal class CreateDateRangeController : IController
    {
        private readonly Context _context;

        public CreateDateRangeController(Context context)
        {
            _context = context;
        }

        public void Show()
        {
            Clear();
        }
        
        public IController Action()
        {
            return new InputDateRangeStartController(_context, new DateRangeBuilder()); 
        }
    }
}