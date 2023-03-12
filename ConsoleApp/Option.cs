namespace ConsoleApp
{
    public class Option
    {
        private int _votes;
        public int Id { get; private set; }
        public int TopicId { get; private set; }
        public string Name { get; private set; }
        public string FullData
        {
            get => $"{Id}. {Name} - {_votes} vote(s)";
        }

        public Option(int id, int topicId, string name)
        {
            Id = id;
            TopicId = topicId; 
            Name = name; 
        }

        public void AddVote()
        {
            _votes++;
        }

        public override string ToString()
        {
            return $"{Id}. {Name}";
        }
    } 
}