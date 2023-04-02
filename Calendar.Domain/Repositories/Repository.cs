using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Calendar.Contracts;

namespace Calendar.Domain.Repositories
{
    internal class Repository : IRepository
    {
        private readonly string _filename;
        private readonly IList<Meeting> _meetings;

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

        public void UpdateMeeting(Meeting updatedMeeting)
        {
            for (int i = 0; i < _meetings.Count; i++)
            {
                if (_meetings[i].Name == updatedMeeting.Name)
                {
                    _meetings[i] = updatedMeeting;
                    DumpToFile();
                    return;
                }
            }
        }

        public IEnumerable<Meeting> GetAllMeetings()
        {
            return _meetings;
        }

        private void DumpToFile()
        {
            using FileStream file = File.Create(_filename);
            JsonSerializer.Serialize(file, _meetings);
        }

        public static IRepository CreateRepository(string filename)
        {
            if (!File.Exists(filename))
            {
                return new Repository(filename, new List<Meeting>());
            }

            using FileStream file = File.OpenRead(filename);
            return new Repository(filename, JsonSerializer.Deserialize<IList<Meeting>>(file));
        }
    }
}