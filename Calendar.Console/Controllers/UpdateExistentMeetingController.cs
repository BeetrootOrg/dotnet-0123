using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calendar.Domain.Builders;

namespace Calendar.Console.Controllers
{
    internal class UpdateExistentMeetingController : IController
    {
        private readonly Context _context;

        public UpdateExistentMeetingController(Context context)
        {
            _context = context;
        }

        public void Show()
        {
            WriteLine();
            WriteLine("Enter meeting name to search:");
        }

        public IController Action()
        {
            string input = ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                WriteLine("Meeting name should be not empty!");
                return this;
            }

            if (input.Length > 20)
            {
                WriteLine("Meeting name length should be less than 20!");
                return this;
            }
            var meeting= _context.Service.GetAllMeetings().FirstOrDefault(x=>x.Name.Equals(input));
            if (meeting == null)
            {
                WriteLine("Nothing found. Try again");
                return this;
            }
            return new MeetingNameInputController(_context, new MeetingBuilder(), meeting);
        }
    }
}
