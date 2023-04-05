using System.Collections.Generic;

using Calendar.Contracts;

namespace Calendar.Console.Controllers
{
    internal class ShowAllMeetingsController : BaseShowMeetingsByRoom
    {
        public ShowAllMeetingsController(Context context) : base(context)
        {
        }

        protected override IEnumerable<Meeting> GetMeetings()
        {
            return _context.Service.GetAllMeetings();
        }
    }
}