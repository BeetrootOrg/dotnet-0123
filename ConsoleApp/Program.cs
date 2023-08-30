
using BookLibrary;

Author author1 = new("Dante", "Klark" , 60, "Italy");
Console.WriteLine(author1.GetFullInfo());

Author author2 = new("Francois", "Rabelais", 59, "France");
Console.WriteLine(author2.GetFullInfo());

Author author3 = new("John", "Smith", 30, "USA");
Console.WriteLine(author3.GetFullInfo());

Author author4 = new(author1);

Book book1 = new()
{
    BookTitle = "Text 1",
    Genre = "Text 2",
    Year = 1953,
    Author = author1
};

Book book2 = new()
{
    BookTitle = "Text 3",
    Genre = "Text 4",
    Year = 1855,
    Author = author2
};

Magazine magazine1 = new()
{
    Topic = "Topic 1",
    Publisher = author3,
    Genre = "Text 5"
};


Library library = new(book1, book2);
System.Console.WriteLine(library.Books.Length);

Reader reader = new(1, "Karl");
Console.WriteLine($"{reader.Id}, {reader.Name}");


Reader reader1 = new()
{
    Id = 2,
    Name = "Ron"
};