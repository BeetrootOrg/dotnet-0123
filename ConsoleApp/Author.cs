namespace Library
{
    public class Author
    {
        public static int _authorId = 1;
        public int AuthorId { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; }

        public Author( string name, string surname)
        {
            AuthorId = _authorId++;
            Name = name;
            Surname = surname;
            FullName = $"{Name} {Surname}";
        }
    }
}