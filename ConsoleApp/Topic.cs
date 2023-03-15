namespace ConsoleApp
{
    public class Topic : IVoteItem
    {
        private static int _id; 
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string ShortTitle { get => $"{Id}. {Name}"; }
        public string FullTitle { get => ShortTitle; }

        public Topic(string name)
        {
            Id = ++_id;
            Name = name;
        }
    }
}