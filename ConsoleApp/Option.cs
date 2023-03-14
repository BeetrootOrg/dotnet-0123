namespace ConsoleApp
{
    public class Option : AbstractItem
    {
        private int _votes;
        public int TopicId { get; private set; }
        
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

        public override string FullData()
        {
           return $"{this.ToString()} - {_votes} vote(s)";
        }
    } 
}