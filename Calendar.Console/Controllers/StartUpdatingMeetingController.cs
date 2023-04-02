using System.Linq;

using Calendar.Domain.Builders;

namespace Calendar.Console.Controllers
{
    internal class StartUpdatingMeetingController : IController
    {
        private readonly Context _context;

        public StartUpdatingMeetingController(Context context)
        {
            _context = context;
        }

        public void Show()
        {
            Clear();

            WriteLine("Enter the name of meeting you want to update:");
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

            if (!_context.Service.GetAllMeetings().Select(x => x.Name).Contains(input))
            {
                WriteLine($"There's no meeting with name {input}");

                WriteLine();
                WriteLine("To continue press ENTER...");
                _ = ReadLine();

                return new MainMenuController(_context);
            }

            return new UpdateMeetingStartInputController(_context, new MeetingBuilder().WithName(input));
        }
    }
}