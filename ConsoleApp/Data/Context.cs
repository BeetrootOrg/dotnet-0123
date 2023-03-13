using ConsoleApp.Models;
using ConsoleApp.Helpers;

namespace ConsoleApp.Data
{
    public class Context
    {
        public List<Topic> Topics { get; } = new List<Topic>();

        public Topic? CreateNewTopic(string name, string description)
        {
            if (string.IsNullOrEmpty(name) || Topics.FirstOrDefault(x => x.Name == name) != null) return null;
            var top = new Topic()
            {
                Id = Topics.Count + 1,
                Name = name,
                Description = description
            };
            Topics.Add(top);
            return top;
        }

        public Topic? GetToppicById(int id) => Topics.FirstOrDefault(x => x.Id == id);
    }
}