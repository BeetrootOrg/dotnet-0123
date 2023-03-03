namespace ConsoleApp
{
    public class BankAccount
    {
        private int Balance {get; set; }
        private string[] OperationsHistory;
        public int Id { get; init; }
        public BankAccount(int id)
        {
            Id = id;
            Balance = 0;
            OperationsHistory = Array.Empty<string>();
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Your balance: {Balance}");
        }
        public void ShowOperationsHistory()
        {
            if (OperationsHistory.Length==0)
            {
                Console.WriteLine("History is empty!");
                return;
            }
            Console.WriteLine("Operation history:");
            foreach (var item in OperationsHistory)
            {
                Console.WriteLine(item);
            }
        }

        private void ChangeOperationsHistory(Operations operation, int sum)
        {
            Array.Resize(ref OperationsHistory, OperationsHistory.Length+1);
            OperationsHistory[^1] = operation.ToString()+": "+sum.ToString();
        }

        public void Deposit(int sum)
        {
            if (sum<0)
            {
                throw new ArgumentException("Invalid output");
            }
            Balance += sum;
            ChangeOperationsHistory(Operations.Deposit,sum);
        }
        public void Withdraw(int sum)
        {
            if (sum<0)
            {
                throw new ArgumentException("Invalid output");
            }
            Balance -= sum;
            ChangeOperationsHistory(Operations.Withdraw,sum);
        }

        private enum Operations
        {
            Deposit,
            Withdraw
        }
    }    
}