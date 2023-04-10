using System;

using ConsoleApp.Contexts;
using ConsoleApp.Models;

using Microsoft.EntityFrameworkCore;

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

Console.WriteLine($"Customer {customer} added to DB");

Customer customerToUpdate = await context.Customers.SingleOrDefaultAsync(c => c.Id == 2);
customerToUpdate.FirstName = "Dima";
customerToUpdate.LastName = "Misik";
context.Entry(customerToUpdate).State = EntityState.Modified;

Customer customerToDelete = new()
{
    Id = 3
};
context.Entry(customerToDelete).State = EntityState.Deleted;

await context.SaveChangesAsync();
