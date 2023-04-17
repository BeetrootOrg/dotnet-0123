// -- Homework 30-Entity Framework
// -- CodeFirst
// --- declare SQL and C# models for the ‘book library’ domain, including:
// --    books
// --    authors
// --    count of each book
// --    customers
// --    history which book was taken by whom and when

using ConsoleApp;

using Microsoft.EntityFrameworkCore;

using Models;

await using var context = new Context();

Author author = new()
{
    FirstName = "Petr",
    LastName = "Last"
};
context.Authors.Add(author);

await context.SaveChangesAsync();
for (int i = 0; i < 10; i++)
{
    Book book = new()
    {
        Title = $"Title {i}",
        Desription = "Desription",
        InitialCount = 10,
        Published = 1970,
        Author = author
    };
    context.Books.Add(book);
}

Customer customer = new()
{
    FirstName = "Ivan",
    LastName = "Name"
};

await context.SaveChangesAsync();
Book takenbook = context.Books.FirstOrDefault(x => x.Id == 6);
if (takenbook == null) return;
Histiry history = new()
{
    Customer = customer,
    Book = takenbook
};
await context.Histiries.AddAsync(history);
await context.SaveChangesAsync();
takenbook = context.Books.Include(x => x.Histiries).FirstOrDefault(x => x.Id == 6);
Console.Write($"book {takenbook} {takenbook?.TakenQty} {takenbook?.FreeQy}");
