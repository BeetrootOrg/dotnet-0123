using ConsoleApp;

BankAccount acc = new(1000);

acc.Deposit(123);
acc.Withdraw(3);

foreach (var item in acc.GetHistory())
{
    Console.WriteLine($"{item.Type} | {item.Amount}");
}

Console.WriteLine($"\n{acc.Balance}");