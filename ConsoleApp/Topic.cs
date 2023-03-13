namespace ConsoleApp
{
    public class Topic
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
    }
}