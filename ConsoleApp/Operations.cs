namespace ConsoleApp
{
    public abstract class Operation
    {
        public abstract int PerformOperation(int a, int b);
    }

    public class Add : Operation
    {
        public override int PerformOperation(int a, int b)
        {
            return a + b;
        }
    }

    public class Subtract : Operation
    {
        public override int PerformOperation(int a, int b)
        {
            return a - b;
        }
    }

    public class Multiply : Operation
    {
        public override int PerformOperation(int a, int b)
        {
            return a * b;
        }
    }

    public class Divide : Operation
    {
        public override int PerformOperation(int a, int b)
        {
            return a / b;
        }
    }
}