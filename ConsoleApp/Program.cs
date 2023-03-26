using System;
using System.Collections.Generic;

BankAccount bankAccount = new BankAccount("frsdf");
System.Console.WriteLine(bankAccount.GetBalance());


public class BankAccount
{
    private string accountNumber;
    private decimal balance;
    private List<string> transactionHistory;

    public BankAccount(string accountNumber)
    {
        this.accountNumber = accountNumber;
        balance = 0;
        transactionHistory = new List<string>();
    }

    public void Deposit(decimal amount)
    {
        balance += amount;
        string transaction = $"Deposited {amount:C} on {DateTime.Now}";
        transactionHistory.Add(transaction);
    }

    public void Withdraw(decimal amount)
    {
        if (amount > balance)
        {
            throw new Exception("Insufficient funds.");
        }

        balance -= amount;
        string transaction = $"Withdrew {amount:C} on {DateTime.Now}";
        transactionHistory.Add(transaction);
    }

    public decimal GetBalance()
    {
        return balance;
    }

    public List<string> GetTransactionHistory()
    {
        return transactionHistory;
    }
}