namespace ConsoleApp
{
    public class Topic : IVoteItem
    {
        private static int _id; 
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Topic(string name)
        {
            Id = ++_id;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Id}. {Name}";
        }

        public string FullData()
        {
            return this.ToString();
        }
    }
}