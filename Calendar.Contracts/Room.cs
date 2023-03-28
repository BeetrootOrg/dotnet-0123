namespace Calendar.Contracts
{
    public record Room
    {
        public string Name { get; init; }
        public void Deconstruct(out string name)
        {
            name = Name;
        }
    }
}