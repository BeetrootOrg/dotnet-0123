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
            return new Repository(filename, JsonSerializer.Deserialize<List<Meeting>>(file));

            // return !File.Exists(filename)
            //     ? new Repository(filename, new List<Meeting>())
            //     : new Repository(
            //     filename,
            //     File.ReadAllLines(filename)
            //         .Skip(1)
            //         .Select(line =>
            //         {
            //             string[] items = line.Split(',');
            //             return new Meeting
            //             {
            //                 Name = items[0],
            //                 Start = DateTime.Parse(items[1]),
            //                 Duration = TimeSpan.Parse(items[2]),
            //                 Room = new Room
            //                 {
            //                     Name = items[3]
            //                 }
            //             };
            //         })
            //         .ToList()
            //);
        }
    }
}