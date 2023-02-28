public class Book
{
    public int BookId { get; }
    public string BookName { get; set; }
    public string Author { get; set; }
    public string Gerne { get; set; }

    public Book(int bookId, string bookName, string author, string gerne)
    {
        BookId=bookId;
        BookName=bookName;
        Author=author;
        Gerne=gerne;

    }
}
