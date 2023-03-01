namespace ConsoleApp
{
    public interface IOperation
    {
        int PerformOperation(int a, int b);
    }

    public class Add : IOperation
    {
        public int PerformOperation(int a, int b)
        {
            return a + b;
        }
    }

    public class Subtract : IOperation
    {
        public int PerformOperation(int a, int b)
        {
            return a - b;
        }
    }

    public class Multiply : IOperation
    {
        public int PerformOperation(int a, int b)
        {
            return a * b;
        }
    }

    public class Divide : IOperation
    {
        public int PerformOperation(int a, int b)
        {
            return a / b;
        }
    }
}