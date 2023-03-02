namespace Library
{
    public class BookAccounting
    {
        public Book Book { get; }
        public bool Availability {get; set;}

        public BookAccounting (Book book, bool availability)
        {
            Book = book;
            Availability = availability;
        }
    }
}