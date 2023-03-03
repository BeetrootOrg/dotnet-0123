namespace BankSystem
{
    public class Operations
    {
        private string Id;
        private decimal Balance;
        private decimal Amount;
        private DateTime Date;

         public Operations(string id, decimal balance, decimal amount, DateTime date)
        {
            Id = id;
            Balance = balance;
            Amount = amount;
            Date = date;
        }

        public string ShowData
        {
            get
            {
                return $"{Id} {Balance} {Amount} {Date}";
            }
        }
    }
}