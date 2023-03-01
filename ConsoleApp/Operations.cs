namespace BankSystem
{
    public class Operations
    {
        private string Id;
        private int Balance;
        private string Amount;
        private DateTime Date;

         public Operations(string id, int balance, string amount, DateTime date)
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