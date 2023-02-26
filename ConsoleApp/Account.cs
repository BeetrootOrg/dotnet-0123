namespace Bank
{
    public class Account
    {
        private static int _id;
        private decimal _balance;
        private Operation[] _operations;
        
        private void RegisterOperation(decimal amount, decimal balance)
        {
            var operations = _operations;
            Array.Resize(ref operations, operations.Length + 1);
            _operations = operations;
            _operations[^1] = new Operation(++_id, DateTime.Now, amount, balance);
        }
        
        public Account()
        {
            _operations = Array.Empty<Operation>();
        }
        
        public void Deposite(decimal amount)
        {
            bool isPositive = Validator.IsPositive(amount); 
            if (isPositive)
            {
                _balance += amount;
                RegisterOperation(amount, _balance);
                Console.WriteLine("Your deposit operation was successful...");
            }
        }
        
        public void Withdraw(decimal amount)
        {
            bool isAvailable = Validator.IsAvailable(amount, _balance);
            if (isAvailable)
            {
                _balance -= amount;
                RegisterOperation(-amount, _balance);
                Console.WriteLine("Your withdraw operation was successful...");
            }
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Your balance is: {_balance}");
        }

        public void ShowOperations()
        {
            if (_operations.Length > 0)
            {
                Console.WriteLine($"{"#",-10}{"Date/Time",-25}{"Amount",25}{"Balance",25}");
                
                foreach (Operation operation in _operations)
                {
                    Console.WriteLine(operation.FormattedData);
                }
            }
            else
            {
                Console.WriteLine("There aren't any data yet");
            }    
        }
    }
}