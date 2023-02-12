
namespace ConsoleApp.Classes
{
    public static class Lesson06
    {
        public static double Distance(float x1,float y1,float x2,float y2){
            double dx=Math.Abs(x2-x1);
            double dy=Math.Abs(y2-y1);
            return Math.Sqrt(dx*dx+dy*dy);
        }
        public static int SumFromTo(int from, int to){
            if (from>to) return SumFromTo(to, from);
            if (from==to) return to;
            return from+SumFromTo(from+1,to);
        }

        public static int Fibonacci(int n)
        {
            if (n == 1 || n == 2) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
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

