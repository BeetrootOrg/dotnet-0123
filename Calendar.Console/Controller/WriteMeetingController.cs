using Calendar.Contracts;
using Calendar.Domain.Builders;
using Calendar.Domain.Exceptions;

namespace Calendar.Console.Controllers
{
    internal class WriteMeetingController : IController
    {
        private readonly Context _context;
        private readonly MeetingBuilder _meetingBuilder;

        public WriteMeetingController(Context context, MeetingBuilder meetingBuilder)
        {
            _context = context;
            _meetingBuilder = meetingBuilder;
        }
        public void Show()
        {
        }

        public IController Action()
        {
            Meeting meeting = _meetingBuilder.Build();
            string oldName = _context.Service.GetBuffer();  
            try
            {
                if (oldName == null)
                {
                    _context.Service.AddMeeting(meeting);
                    WriteLine("Meeting successfully created!");
                }
                else
                {
                    _context.Service.UpdateMeeting(meeting, oldName);
                    WriteLine($"Meeting with old name: {oldName} was updated!");
                    _context.Service.SetBuffer(null);
                }
            }
            catch (CalendarException ce)
            {
                WriteLine(ce.Message);
            }

            WriteLine("To continue press ENTER...");
            ReadLine();

            return new MainMenuController(_context);
        }
    }
}