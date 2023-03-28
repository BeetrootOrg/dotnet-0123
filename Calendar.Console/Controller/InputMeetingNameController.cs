using Calendar.Domain.Builders;

namespace Calendar.Console.Controllers
{
    internal class InputMeetingNameController : IController
    {
        private readonly Context _context;
        private readonly MeetingBuilder _meetingBuilder;

        public InputMeetingNameController(Context context, MeetingBuilder meetingBuilder)
        {
            _context = context;
            _meetingBuilder = meetingBuilder;
        }

        public void Show()
        {
            WriteLine("Enter meeting name:");
        }
        
        public IController Action()
        {
            string input = ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                WriteLine("Meeting name should be not empty");
                return this;
            }

            if (input.Length > 20)
            {
                WriteLine("Meeting name length should be less than 20");
                return this;
            }

            return new InputMeetingStartController(_context, _meetingBuilder.WithName(input));
        }
    }
}