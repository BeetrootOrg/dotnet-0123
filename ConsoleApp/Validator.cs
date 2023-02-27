namespace Bank
{
    public static class Validator
    {
        public static bool IsPositive(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Error! Value could not be negative or equals zero");
                return false;
            }
            return true;
        }

        public static bool IsAvailable(decimal amount, decimal balance)
        {
            if (amount > balance)
            {
                Console.WriteLine("Error! Withdraw value is more than exceed than current balance");
                return false;
            }
            return true;
        }
    } 
}