namespace ConsoleApp
{
    public class Option : IVoteItem
    {
        private int _votes;
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int TopicId { get; private set; }
        public string ShortTitle { get => $"{Id}. {Name}"; }
        public string FullTitle { get => $"{ShortTitle} - {_votes} vote(s)"; }
        
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
    } 
}