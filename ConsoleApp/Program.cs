using System;

using ConsoleApp.Contexts;
using ConsoleApp.Models;

Customer customer = new()
{
    FirstName = Guid.NewGuid().ToString(),
    LastName = Guid.NewGuid().ToString(),
    Email = $"{Guid.NewGuid():N}@gmail.com",
    Address = Guid.NewGuid().ToString(),
    PhoneNumber = Guid.NewGuid().ToString()
};

await using ShopContext context = new();
await context.AddAsync(customer);

await context.SaveChangesAsync();

Console.WriteLine($"Customer {customer} added to DB");