namespace BankApp
{
    public class BankAccount
    {
        private decimal _amount = 0;
        private string[] _operationHistory = Array.Empty<string>();
    
        public string IBAN { get; init; }
        public decimal Amount { get; private set; }
        private string[] OperationHistory {get; set;} 

        public BankAccount(string iban)
        {
            IBAN = iban;
            Amount = _amount;
            OperationHistory = _operationHistory;
        }

        private void AddToOperationHistory(string operation, decimal sum)
        {
            Array.Resize(ref _operationHistory, _operationHistory.Length+1);
            if(operation == "+")
            {
                _operationHistory[^1] = $"Put money: {sum}";
            }
            if(operation == "-") 
            {
                _operationHistory[^1] = $"Withdraw money: {sum}";
            }
        }

        public void ShowOperationHistory()
        {
            Console.WriteLine($"Account transaction history by IBAN {IBAN}");
            foreach(string x in _operationHistory)
            {
               Console.WriteLine(x);; 
            }
        }
        public void ShowBalance()
        {
            Console.WriteLine($"Account balance {IBAN}: {_amount} UAH");
        }   
        
        public decimal PutMoney(decimal sum)
        {
            _amount += sum;
            AddToOperationHistory("+", sum);
            return _amount;
        }
        
        public decimal WithdrawMoney(decimal sum)
        {
            if (_amount-sum < 0)
            {
                throw new Exception("Not enough money in the account");
            }
            if (sum < 0)
            {
                throw new Exception("Specified a negative amount");
            }
            _amount -= sum;
            AddToOperationHistory("-", sum);
            return _amount;
        }
    }
}