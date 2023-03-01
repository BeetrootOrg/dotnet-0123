namespace Library
{
    public class Record
    {
        public Books Book { get; }
        public Client Client { get; }
        public DateTime TakingDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public Record(Books book, Client client, DateTime takingDate, DateTime returnDate)
        {
            Book = book ?? throw new ArgumentNullException(nameof(book));
            Client = client ?? throw new ArgumentNullException(nameof(client));
            TakingDate = takingDate;
            ReturnDate = returnDate;
        }
    }
}