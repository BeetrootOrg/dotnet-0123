using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
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
            Meeting currentMeeting = _meetings.Where(m => m.Name.Equals(oldName)).FirstOrDefault();
            currentMeeting.Rewrite(meeting);
            
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
            File.WriteAllText(_filename, JsonSerializer.Serialize(_meetings));
        }

        public static IRepository CreateRepository(string filename)
        {
            return !File.Exists(filename)
                ? new Repository(filename, new List<Meeting>())
                : new Repository(
                filename,
                JsonSerializer.Deserialize<List<Meeting>>(File.ReadAllText(filename))
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