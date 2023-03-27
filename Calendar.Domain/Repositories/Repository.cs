using System;
using System.Collections.Generic;
using Calendar.Contracts;

namespace Calendar.Domain.Repositories
{
    internal class Repository : IRepository
    {
        // private List<Meeting> _meetings;
        // public Repository(List<Meeting> meetings)
        // {
        //     _meetings = meetings;
        // }

        public void AddMeeting(Meeting meeting)
        {
            System.Console.WriteLine("Meeting was added...");
        }

        public IEnumerable<Meeting> GetAllMeetings()
        {
            // ToDo read from file
            return new Meeting[]
            {
                new()
                {
                    Name = "Meeting 1",
                    Start = new DateTime(2024, 01, 01),
                    Duration = TimeSpan.FromMinutes(60),
                    Room = new Room
                    {
                        Name = "Room 1"
                    }
                },
                new()
                {
                    Name = "Meeting 2",
                    Start = new DateTime(2025, 03, 10),
                    Duration = TimeSpan.FromMinutes(15),
                    Room = new Room
                    {
                        Name = "Room 2"
                    }
                }
            };
        }
    }
}