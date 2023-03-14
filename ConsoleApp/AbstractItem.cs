namespace ConsoleApp
{
    public abstract class AbstractItem : IVoteItem
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        
        public override string ToString()
        {
            return $"{Id}. {Name}";
        }

        public virtual string FullData()
        {
            return this.ToString();
        }
    }
}