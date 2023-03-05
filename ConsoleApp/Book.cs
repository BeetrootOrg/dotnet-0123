namespace ConsoleApp
{
    class Book
    {
        public string Title { get; set; }
        public int NumberOfPages { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public Author Author { get; set; }
    }
}