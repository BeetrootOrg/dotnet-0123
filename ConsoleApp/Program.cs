using ConsoleApp.DbContexts;

using Microsoft.EntityFrameworkCore;

await using var context = new ShopContext();

var authorsCount = await context.TblAuthors.CountAsync();
Console.WriteLine($"There are {authorsCount} authors");

var authors = await context.TblAuthors.ToArrayAsync();

foreach (var author in authors)
{
    Console.WriteLine($"Customer number {author.Id} {author.FirstName} {author.LastName} wrote {author.TblBooks.Count} books");

}