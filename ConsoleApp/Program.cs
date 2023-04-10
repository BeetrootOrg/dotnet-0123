using ConsoleApp.DbContexts;
using ConsoleApp.Models;

using Microsoft.EntityFrameworkCore;

await using ShopContext context = new();

int customersCount = await context.TblCustomers.CountAsync();
Console.WriteLine($"There are {customersCount} customers");

TblCustomer[] customers = await context.TblCustomers.ToArrayAsync();
foreach (TblCustomer customer in customers)
{
    Console.WriteLine($"Customer #{customer.Id} ({customer.FirstName} {customer.LastName})");
}