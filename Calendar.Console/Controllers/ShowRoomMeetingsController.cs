using System;
using System.Linq;

using Calendar.Contracts;

namespace Calendar.Console.Controllers
{
    internal class ShowRoomMeetingsController : IController
    {
        private readonly Context _context;
        private readonly Room _searchByRoom;

        public ShowRoomMeetingsController(Context context, Room searchByRoom)
        {
            _context = context;
            _searchByRoom = searchByRoom;
        }

        public void Show()
        {
            Clear();

            System.Collections.Generic.IEnumerable<Meeting> meetings = _context.Service.GetAllMeetings().Where(item => item.Room.Name == _searchByRoom.Name);

            WriteLine($"{"Name",-25}{"Start",-25}{"End",-25}{"Room",-25}");
            foreach ((string name, DateTime start, TimeSpan duration, Room room) in meetings)
            {
                DateTime end = start.Add(duration);
                WriteLine($"{name,-25}{start,-25}{end,-25}{room.Name,-25}");
            }

            WriteLine();
            WriteLine("To continue press ENTER...");
        }
        public IController Action()
        {
            _ = ReadLine();
            return new MainMenuController(_context);
        }
    }
}