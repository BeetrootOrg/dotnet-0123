namespace BankSystem
{
    public class Client
    {
        private string Id;
        private decimal Balance;
        private Operations[] operations;


        private void AddOperation(decimal amount, decimal balance)
        {
            var operation = operations;
            Array.Resize(ref operations, operations.Length + 1);
            operations = operation;
            operation[^1] = new Operations(Id, balance, amount, DateTime.Now);
        }

        private void Deposit(decimal amount, decimal balance)
        {
            if (amount > 0)
            {
                balance += amount;
                AddOperation(amount, balance);
            }
            else
            {
                throw new ArgumentException("Amount must be bigger than 0!");
            }
        }

        private void Withdraw(decimal amount, decimal balance)
        {
            if (amount <= balance && amount > 0)
            {
                balance -= amount;
                AddOperation(-amount, balance);
            }
            else
            {
                throw new ArgumentException($"Amount must be bigger than 0! or Not enougt money in the balance!");
            }
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Balance: {Balance}");
        }
        public void ShowOperations()
        {
            if (operations.Length > 0)
            {  
                foreach (Operations operation in operations)
                {
                    Console.WriteLine(operation.ShowData);
                }
            }
            else
            {
                Console.WriteLine("There aren't any data yet");
            }    
        }
        
    }
}