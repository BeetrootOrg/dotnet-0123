using ConsoleApp.DbContexts;
using ConsoleApp.Models;

using Microsoft.EntityFrameworkCore;

await using ShopContext context = new();

TblCustomer[] customers = await context.TblCustomers.ToArrayAsync();
Console.WriteLine($"There are {customers.Length} customers");