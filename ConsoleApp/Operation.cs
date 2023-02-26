namespace Bank
{
    class Operation
    {
        private int _id;
        private DateTime _date;
        private decimal _amount;
        private decimal _balance;

        public Operation(int id, DateTime date, decimal amount, decimal balance)
        {
            _id = id;
            _date = date;
            _amount = amount;
            _balance = balance;
        }

        public string ShowOperation()
        {
            return $"{_id,-10}{_date,-25}{_amount,25}{_balance,25}";
        }
    } 
}