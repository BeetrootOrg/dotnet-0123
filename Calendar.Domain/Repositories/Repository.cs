using System.Collections.Generic;
using System;
using Calendar.Contracts;

namespace  Calendar.Domain.Repositories
{
    internal class Repository : IRepository
    {
        public IEnumerable<Meeting>GetAllMeetings()
        {
            // ToDo: read from file
            return new Meeting[]
            {
                new()
                {
                    Name = "meeting1",
                    Start = new DateTime(2024, 01, 01),
                    Duration = TimeSpan.FromMinutes(60),
                    Room = new Room
                    {
                        Name = "room1"
                    }
                },
                new()
                {
                    Name = "meeting2",
                    Start = new DateTime(2025, 03, 10),
                    Duration = TimeSpan.FromMinutes(15),
                    Room = new Room
                    {
                        Name = "room2"
                    }
                }
            };
        }
    }
}