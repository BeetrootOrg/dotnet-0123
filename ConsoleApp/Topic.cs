namespace ConsoleApp
{
    public class Topic : AbstractItem
    {
        private static int _id; 

        public Topic(string name)
        {
            Id = ++_id;
            Name = name;
        }
    }
}