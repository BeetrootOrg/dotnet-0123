using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calendar.Contracts;
using Calendar.Domain.Builders;
using Calendar.Domain.Exceptions;
using Calendar.Domain.Services;

namespace Calendar.Console.Controllers
{
    internal class UpdateMeetingController : IController
    {
        private readonly Context _context;
        private readonly MeetingBuilder _meetingBuilder;
        private readonly Meeting _meeting;
        public UpdateMeetingController(Context context, Meeting meeting)
        {
            _context = context;
            _meeting = meeting;
        }

        public void Show()
        {
        }

        public IController Action()
        {
            

            try
            {
                _context.Service.DoesIntersectWithOtherNonStatic(_context.Service.GetAllMeetings(), _meeting);
                _context.Service.DumpToFile();
                WriteLine("Meeting successfully updated!");
            }
            catch (CalendarException ce)
            {
                WriteLine(ce.Message);
            }

            WriteLine("To continue press ENTER...");
            _ = ReadLine();

            return new MainMenuController(_context);
        }
    }
}
