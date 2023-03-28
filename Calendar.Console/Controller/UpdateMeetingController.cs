using System.Linq;

using Calendar.Domain.Builders;

namespace Calendar.Console.Controllers
{
    internal class UpdateMeetingController : IController
    {
        private readonly Context _context;

        public UpdateMeetingController(Context context)
        {
            _context = context;
        }

        public void Show()
        {
            WriteLine("Enter meeting name for update:");
        }
        public IController Action()
        {
            string input = ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                WriteLine("Meeting name should be not empty");
                return this;
            }

            var meeting = _context.Service.GetAllMeetings().Where(m => m.Name == input).FirstOrDefault();
            
            if (meeting == null)
            {
                WriteLine($"There are not the meeting with Name: {input}");
                return this;    
            }

            _context.Service.SetBuffer(input);
            
            return new InputMeetingNameController(_context, new MeetingBuilder()); 
        }
    }
}