namespace BookLibrary
{
    public class Book
    {
        public Author Author { get; set; }
        public Genre Genre { get; set; }
        public string Name { get; set; } 
        public int? Year { get; set; }

        public Book(Author author, Genre genre, string name) : this(author, genre,  name, null)
        {}

        public Book(Author author, Genre genre,  string name, int? year)
        {
            Author = author;
            Genre = genre; 
            Name = name;
            Year = year;
        }
    }
}
