using System;
using System.Collections.Generic;
using System.Linq;

using Calendar.Contracts;

namespace Calendar.Console.Controllers
{
    internal class ShowMeetingsByRoomController : IController
    {
        private readonly Context _context;
        private readonly string _roomName;

        public ShowMeetingsByRoomController(Context context, string roomName)
        {
            _context = context;
            _roomName = roomName;
        }

        public void Show()
        {
            Clear();

            IEnumerable<Meeting> meetings = _context.Service.GetAllMeetings()
                .Where(m => m.Room.Name == _roomName);

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
            ReadLine();
            return new MainMenuController(_context);
        }
    }
}