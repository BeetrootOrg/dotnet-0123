using ConsoleApp.DbContexts;
using ConsoleApp.Models;

using Microsoft.EntityFrameworkCore;

await using ShopContext context = new();

int customersCount = await context.TblCustomers.CountAsync();
Console.WriteLine($"There are {customersCount} customers");

TblCustomer[] customers = await context.TblCustomers
    .Include(customer => customer.TblOrders)
    .ThenInclude(order => order.Employee)
    .Include(customer => customer.TblOrders)
    .ThenInclude(order => order.TblOrdersProducts)
    .ThenInclude(orderProduct => orderProduct.Product)
    .ToArrayAsync();

foreach (TblCustomer customer in customers)
{
    Console.WriteLine($"Customer #{customer.Id} ({customer.FirstName} {customer.LastName}) has {customer.TblOrders.Count} orders");
}