namespace BookLibrary
{
    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        //public string FullName { get; } If I want only get this value;

        // public string FullName => $"{FirstName} {LastName}"; If I want to change value;
        public int Age { get; set; }
        public string Country { get; set; }

        public Author(string firstName, string lastName, int age, string country)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Country = country;
        }

        public Author() {}

        public Author(Author author) : this(author.FirstName, author.LastName, author.Age, author.Country)
        {
            // The same like -- this(author.FirstName...)
            //FirstName = author.FirstName;
            //LastName = author.LastName;
            //Age = author.Age;
            //Country = author.Country;
        }

        public string GetFullInfo()
        {
            return $"{FirstName}, {LastName}, {Age}, {Country}";
        }
    }
}