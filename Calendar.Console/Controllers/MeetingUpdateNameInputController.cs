using Calendar.Domain.Builders;

namespace Calendar.Console.Controllers
{
    internal class MeetingUpdateNameInputController : IController
    {
        private readonly Context _context;
        private readonly MeetingBuilder _meetingBuilder;

        public MeetingUpdateNameInputController(Context context, MeetingBuilder meetingBuilder)
        {
            _context = context;
            _meetingBuilder = meetingBuilder;
        }

        public void Show()
        {
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
            if (_context.Service.IsAnyMeetingWithThisName(input))
            {
                return new MeetingUpdateStartInputController(_context, _meetingBuilder.WithName(input));
            }

            WriteLine("There are no meetings with this name!");
            WriteLine("To continue press ENTER...");
            _ = ReadLine();

            return new MainMenuController(_context);
        }
    }
}