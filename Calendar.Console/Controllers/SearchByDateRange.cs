namespace Calendar.Console.Controllers
{
    internal class SearchByDateRange : IController
    {
        private readonly Context _context;

        public SearchByDateRange(Context context)
        {
            _context = context;
        }

        public void Show()
        {
            Clear();
        }

        public IController Action()
        {
            return new DateRangeStartInputController(_context);
        }
    }
}