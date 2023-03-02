namespace Library
{
    public class Record
    {
        public Book Book { get; }
        public Client Client { get; }
        public DateTime TakingDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public Record(Book book, Client client, DateTime takingDate, DateTime returnDate)
        {
            Book = book;
            Client = client;
            TakingDate = takingDate;
            ReturnDate = returnDate;
        }
    }
}