namespace BookLibrary
{
    public class Library
    {
        public Book[] Books { get; set; }
        public Magazine[] Magazines { get; set; }
        
        public Library(params Book[] books)
        {
           
            Books = books;
        }
    }
}