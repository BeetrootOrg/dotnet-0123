namespace ConsoleApp
{
    class BookInUse
    {
        public Book Book { get; set; }
        public ReaderCard CurrentOwner { get; set; }
        public DateTime StartUsing { get; set; }
        public DateTime EndUsing { get; set; }
    }
}