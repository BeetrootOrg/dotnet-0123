using System.Xml.Serialization;

using ConsoleApp.Models;
namespace ConsoleApp.Data
{
    public class Context
    {
        const string file = "./data.xml";
        public List<Topic> Topics { get; private set; } = new();

        public Context()
        {
            Load();
        }

        public Topic CreateTopic(string name)
        {
            if (string.IsNullOrEmpty(name) || Topics.FirstOrDefault(x => x.Name == name) != null) return null;
            Topic topic = new() { Id = Topics.Count + 1, Name = name };
            Topics.Add(topic);
            Save();
            return topic;
        }

        public Option CreateOptionForTopic(string name, Topic topic)
        {
            if (string.IsNullOrEmpty(name) || topic == null || Topics.FirstOrDefault(x => x.Name == name) != null) return null;
            Option option = new() { Id = topic.Options.Count + 1, Name = name };
            topic.Options.Add(option);
            Save();
            return option;
        }

        public Topic GetTopicById(int id) => Topics.FirstOrDefault(X => X.Id == id);
        public string TopicResult(Topic topic) => $"{topic.Name}\n\t{string.Join("\n\t", topic.Options.Select(x => $"{x.Name}- {x.VoteCounter} vote(s)").ToArray())}";

        public void Load()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(Topics.GetType());
            try
            {
                using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
                {
                    Topics = xmlSerializer.Deserialize(fs) as List<Topic>;
                    if (Topics == null) Topics = new();
                }
            }
            catch
            { if (Topics == null) Topics = new(); }
        }
        public void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(Topics.GetType());
            using (FileStream fs = new FileStream(file, FileMode.Truncate))
            {
                xmlSerializer.Serialize(fs, Topics);
            }
        }
    }
}