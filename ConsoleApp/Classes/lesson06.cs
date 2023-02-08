
namespace ConsoleApp.Classes
{
    public static class Lesson06
    {
        public static void Test()
        {
            Console.WriteLine("Test");
        }

        public static long Factorial(int n)
        {
            if (n == 0) return 1;
            return n * Factorial(n - 1);
        }
    }
}

