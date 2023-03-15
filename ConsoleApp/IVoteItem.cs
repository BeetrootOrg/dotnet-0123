namespace ConsoleApp
{
    public interface IVoteItem
    {
        public int Id { get; } 
        public string Name { get; } 
        public string ShortTitle { get; }
        public string FullTitle { get; }
    }
}