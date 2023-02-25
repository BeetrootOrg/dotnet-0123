using BookLibrary;

Genre genre = new Genre("Science fiction");
Console.WriteLine(genre.Name);

Author author = new Author("Kurt", "Vonnegut");
Console.WriteLine($"{author.FirstName} {author.LastName}");

Book book = new Book(author, genre, "The Sirens of Titan");
Console.WriteLine($"{book.Name}");

Reader reader = new Reader("John", "Doe");
Console.WriteLine($"Reader Id: {reader.Id}, Full Name: {reader.FirstName} {reader.LastName}");

ReaderCard readerCard = new ReaderCard(reader);
Console.WriteLine($"Card of reader: {reader.FirstName} {reader.LastName}"); 
