using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

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

        public void DumpToFile()
        {
            try
            {
                if (!File.Exists(_filename)) File.Create(_filename);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(IList<Meeting>));
                using (var file = new FileStream(_filename, FileMode.Truncate))
                {
                    xmlSerializer.Serialize(file, _meetings);
                }
            }
            catch
            {
                Console.WriteLine($"Can not write file {_filename}");
            }
        }

        public static IRepository CreateRepository(string filename)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(IList<Meeting>));
                var list=new List<Meeting>();
                using (var file = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    list  = xmlSerializer.Deserialize(file) as List<Meeting>;
                }
                return new Repository(filename,list);
            }
            catch
            {
                Console.WriteLine($"Can not read file {filename}");
                return new Repository(filename,new List<Meeting>());
            }
        }
    }
}