using Calendar.Contracts;
using Calendar.Domain.Builders;

namespace Calendar.Console.Controllers
{
    internal class MeetingNameInputController : IController
    {
        private readonly Context _context;
        private readonly MeetingBuilder _meetingBuilder;
        private readonly Meeting _meeting;

        public MeetingNameInputController(Context context, MeetingBuilder meetingBuilder, Meeting meeting=null)
        {
            _context = context;
            _meetingBuilder = meetingBuilder;
            _meeting = meeting;
        }

        public void Show()
        {
            if (_meeting != null) 
            {
                WriteLine($"Meeting name {_meeting.Name}. Enter new name:");
            } 
            else
            WriteLine("Enter meeting name:");
        }

        IController IController.Action()
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
            if (_meeting!=null) _meeting.Name=input;
            return new MeetingStartInputController(_context, _meetingBuilder.WithName(input), _meeting);
        }
    }
}