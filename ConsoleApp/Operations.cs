namespace ConsoleApp
{
    public interface IOperation
    {
        int PerformOperation(int a, int b);
    }

    public interface IOperationFactory
    {
        IOperation CreateOperation(OperationType operationType);
    }

    public class Add : IOperation
    {
        public static readonly IOperation Instance = new Add();

        private Add() { }

        public int PerformOperation(int a, int b)
        {
            return a + b;
        }
    }

    public class Subtract : IOperation
    {
        public static readonly IOperation Instance = new Subtract();

        private Subtract() { }

        public int PerformOperation(int a, int b)
        {
            return a - b;
        }
    }

    public class Multiply : IOperation
    {
        public static readonly IOperation Instance = new Multiply();

        private Multiply() { }

        public int PerformOperation(int a, int b)
        {
            return a * b;
        }
    }

    public class Divide : IOperation
    {
        public static readonly IOperation Instance = new Divide();

        private Divide() { }

        public int PerformOperation(int a, int b)
        {
            return a / b;
        }
    }

    public class Pow : IOperation
    {
        public static readonly IOperation Instance = new Pow();

        private Pow() { }

        public int PerformOperation(int a, int b)
        {
            return (int)Math.Pow(a, b);
        }
    }

    public class OperationFactory : IOperationFactory
    {
        public IOperation CreateOperation(OperationType operationType)
        {
            return operationType switch
            {
                OperationType.Unknown => throw new ArgumentException("Unknown operation", nameof(operationType)),
                OperationType.Add => Add.Instance,
                OperationType.Subtract => Subtract.Instance,
                OperationType.Multiply => Multiply.Instance,
                OperationType.Divide => Divide.Instance,
                OperationType.Pow => Pow.Instance,
                _ => throw new ArgumentException($"Unknown value {operationType}", nameof(operationType)),
            };
        }
    }
}
