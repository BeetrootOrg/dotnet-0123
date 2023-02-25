namespace BookLibrary
{
    public class BookInCard
    {
        public Book Book { get; set; }
        public DateTime DateGet { get; }
        public DateTime? DateReturn { get; set; }

        public BookInCard(Book book )
        {
            Book = book;
            DateGet = DateTime.Now;
            DateReturn = null;
        } 
    }
}