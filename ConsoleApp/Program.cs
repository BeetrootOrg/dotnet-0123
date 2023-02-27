//-------------28/02/2023------------------
//---------------homework
// Create class(es) describing ‘bank account’. It should be possible to perform next operations:
//    deposit/withdraw money
//    see balance
//    see operations history
// User of created classes should not be able to perform other operations
using ConsoleApp.Models;
var context = new Context(100.0M);
context.Deposit(300.0M);
context.Deposit(300.0M);
context.Withdraw(100.0M);
context.Withdraw(100.0M);
context.Withdraw(100.0M);
context.Withdraw(100.0M);
context.Withdraw(100.0M);
Console.WriteLine($"Balance: {context.Balance}");
foreach (var s in context.Operations)
{
    Console.WriteLine($"{s}");
}
