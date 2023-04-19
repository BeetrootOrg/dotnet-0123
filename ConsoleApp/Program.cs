using ConsoleApp.DbContexts;
using ConsoleApp.Models;

await using LibraryContext context = new();
// TblCustomer[] customers = await context.TblCustomers.ToArrayAsync();

// foreach (TblCustomer item in customers)
// {
//     Console.WriteLine($"{item.FirstName} {item.LastName}");
// }
TblCustomer customer = new TblCustomer
{
    FirstName = "Peter",
    LastName = "Doe",
    Email = "peterDoe@post.com",
    Phone = "1234567890",
    Address = "123 Main St"
};
context.TblCustomers.Add(customer);
await context.SaveChangesAsync();
