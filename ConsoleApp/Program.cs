using BookLibrary;

Genre genre = new Genre("Science fiction");
Console.WriteLine($"Genre: {genre.Name}");

Author author = new Author("Kurt", "Vonnegut");
Console.WriteLine($"Author: {author.FirstName} {author.LastName}");

Book book1 = new Book(author, genre, "The Sirens of Titan");
Console.WriteLine($"Book: {book1.Name}");

Member member = new Member("John", "Doe");
Console.WriteLine($"Member Id: {member.Id}, Full Name: {member.FirstName} {member.LastName}");

Card card = new Card(member);
Console.WriteLine($"Card: {card.Member.FirstName} {card.Member.LastName}"); 

BookInCard bookInCard = new BookInCard(book1); 

var books = card.Books;
Array.Resize(ref books, card.Books.Length + 1);
card.Books = books;

card.Books[^1] = bookInCard;

Console.WriteLine($"Books in the card of {card.Member.FirstName} {card.Member.LastName}");
foreach (BookInCard book in card.Books)
{
    Console.WriteLine($"{book.Book.Name}\t{book.DateGet}\t{book.DateReturn}");
}