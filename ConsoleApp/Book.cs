namespace Library
{
    public class Book
    {
        public static int _bookId = 1;
        public int BookId { get; set; }
        public string BookName { get; set; }
        public Author Author { get;}
        public string Gerne { get; set; }

        public Book
        (string bookName, Author author, string gerne)
        {
            BookId =_bookId++;
            BookName = bookName;
            Author = author;
            Gerne = gerne;
        }
    }
    
}