using BankApp;

BankAccount first = new BankAccount("0001");
Console.WriteLine(first.IBAN);
Console.WriteLine(first.Amount);

first.PutMoney(200);
first.WithdrawMoney(30);
first.PutMoney(70);
first.ShowOperationHistory();