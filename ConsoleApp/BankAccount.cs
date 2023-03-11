namespace ConsoleApp
{
    class BankAccount
    {
        public decimal Balance { get; private set; }
        private List<Operation> _operations = new();
        public BankAccount(decimal balance)
        {
            Balance = balance;
            _operations.Add(new Operation(OperationType.Deposit, balance));
        }
        public void Deposit(decimal amount)
        {
            Balance += amount;
            _operations.Add(new Operation(OperationType.Deposit, amount));
        }
        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentException("Insufficient balance on the account.");
            }
            Balance -= amount;
            _operations.Add(new Operation(OperationType.Withdrawal, amount));
        }
        public IEnumerable<Operation> GetHistory()
        {
            return _operations;
        }
    }
}