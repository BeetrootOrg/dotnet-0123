namespace ConsoleApp
{
    public class Option : IVoteItem
    {
        private int _votes;
        public int Id { get; private set; }
        public int TopicId { get; private set; }
        public string Name { get; private set; }
        
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

        public string FullData()
        {
            return $"{this.ToString()} - {_votes} vote(s)";
        }
    } 
}