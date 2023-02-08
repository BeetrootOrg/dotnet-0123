
namespace ConsoleApp.Classes
{
    public static class Lesson06
    {
        public static int Sum(int a, int b)
        {
            int sum = a + b;
            return sum;
        }
        public static void Test()
        {
            Console.WriteLine("Test");
        }

        public static long Factorial(int n)
        {
            if (n == 0) return 1;
            return n * Factorial(n - 1);
        }

        public static void WriteNumbers(int n)
        {
            if (n > 0)
            {
                Console.Write(n);
                WriteNumbers(n - 1);
            }
        }
    }
}

