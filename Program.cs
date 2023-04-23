using dotnet_0123.DbContexts;

using Microsoft.EntityFrameworkCore;

await using var context = new ShopContext();

var count = await context.TblBooks.CountAsync();
Console.WriteLine($"There {count} books in library");
