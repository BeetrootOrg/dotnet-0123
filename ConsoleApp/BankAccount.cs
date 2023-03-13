namespace ConsoleApp
{
    public enum OperationType
    {
        Deposit,
        Withdraw
    }

    public class Operation
    {
        public decimal Amount { get; init; }
        public DateTime Date { get; init; }
        public OperationType Type { get; init; }
    }

    public class BankAccount
    {
        private Operation[] _operations = Array.Empty<Operation>();

        public decimal Balance { get; private set; }

        public void Deposit(decimal amount)
        {
            VerifyAmount(amount);

            Array.Resize(ref _operations, _operations.Length + 1);
            _operations[^1] = new Operation
            {
                Amount = amount,
                Date = DateTime.Now,
                Type = OperationType.Deposit
            };

            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            VerifyAmount(amount);

            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not enough money!");
            }

            Array.Resize(ref _operations, _operations.Length + 1);
            _operations[^1] = new Operation
            {
                Amount = amount,
                Date = DateTime.Now,
                Type = OperationType.Withdraw
            };

            Balance -= amount;
        }

        public Operation[] Operations()
        {
            Operation[] operations = new Operation[_operations.Length];
            Array.Copy(_operations, operations, _operations.Length);
            return operations;
        }

        private static void VerifyAmount(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive"
            }
        }
    }
}