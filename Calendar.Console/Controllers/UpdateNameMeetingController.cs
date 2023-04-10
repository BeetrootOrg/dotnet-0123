using System.Linq;

using Calendar.Domain.Builders;

namespace Calendar.Console.Controllers
{
    internal class UpdateNameMeetingController : IController
    {
        private readonly Context _context;
        private readonly MeetingBuilder _meetingBuilder;

        public UpdateNameMeetingController(Context context, MeetingBuilder meetingBuilder)
        {
            _context = context;
            _meetingBuilder = meetingBuilder;
        }

        public void Show()
        {
            Clear();

            WriteLine("Enter meeting name:");
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

            if (_context.Service.GetAllMeetings().Any(item => item.Name == input))
            {
                return new UpdateMeetingController(_context, _meetingBuilder.WithName(input));
            }


            WriteLine("There are no meetings with this name!");
            WriteLine("To continue press ENTER...");
            _ = ReadLine();

            return new MainMenuController(_context);
        }
    }
}