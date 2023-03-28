using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Calendar.Contracts;

namespace Calendar.Domain.Repositories
{
    internal class Repository : IRepository
    {
        private readonly string _filename;
        private readonly IList<Meeting> _meetings;
        private string _buffer;

        public Repository(string filename, IList<Meeting> meetings)
        {
            _filename = filename;
            _meetings = meetings;
        }

        public void AddMeeting(Meeting meeting)
        {
            _meetings.Add(meeting);
            DumpToFile();
        }

        public void UpdateMeeting(Meeting meeting, string oldName)
        {
            for (int i = 0; i < _meetings.Count; i++)
            {
                if (_meetings[i].Name.Equals(oldName))
                {
                    _meetings[i] = _meetings[i].Rewrite(meeting);
                    break;
                }
            }
            
            DumpToFile();
        }

        public IEnumerable<Meeting> GetAllMeetings()
        {
            return _meetings;
        }

        private void DumpToFile()
        {
            File.WriteAllLines(
                _filename,
                _meetings.Select(meeting => $"{meeting.Name},{meeting.Start},{meeting.Duration},{meeting.Room.Name}")
                    .Prepend("Name,Start,Duration,Room")
            );
        }

        public static IRepository CreateRepository(string filename)
        {
            return !File.Exists(filename)
                ? new Repository(filename, new List<Meeting>())
                : new Repository(
                filename,
                File.ReadAllLines(filename)
                    .Skip(1)
                    .Select(line =>
                    {
                        string[] items = line.Split(',');
                        return new Meeting
                        {
                            Name = items[0],
                            Start = DateTime.Parse(items[1]),
                            Duration = TimeSpan.Parse(items[2]),
                            Room = new Room
                            {
                                Name = items[3]
                            }
                        };
                    })
                    .ToList()
            );
        }

        public void SetBuffer(string buffer)
        {
            _buffer = buffer;
        }

        public string GetBuffer()
        {
            return _buffer;
        }
    }
}