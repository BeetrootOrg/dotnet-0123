namespace ConsoleApp
{
    public class SingleResponsibility
    {
        // Single Responsibility Violation
        public static bool CheckPositiveBad(int a)
        {
            if (a < 0)
            {
                Console.WriteLine("Number is negative");
                return false;
            }

            return true;
        }

        public static bool CheckPositiveGood(int a)
        {
            return a >= 0;
        }
    }
}
