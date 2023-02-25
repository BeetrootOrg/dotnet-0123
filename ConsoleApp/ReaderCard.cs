namespace BookLibrary
{
    public class ReaderCard
    {
        public Reader Reader { get; set; }
        public (Book book, DateTime start, DateTime end)[] Books { get; } 

        public ReaderCard(Reader reader)
        {
            Reader = reader;
            Books = Array.Empty<(Book, DateTime, DateTime)>();
        }
    }
} 