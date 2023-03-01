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

    public class OperationFactory : IOperationFactory
    {
        public IOperation CreateOperation(OperationType operationType)
        {
            return operationType switch
            {
                OperationType.Unknown => throw new ArgumentException("Unknown operation", nameof(operationType)),
                OperationType.Add => new Add(),
                OperationType.Subtract => new Subtract(),
                OperationType.Multiply => new Multiply(),
                OperationType.Divide => new Divide(),
                _ => throw new ArgumentException($"Unknown value {operationType}", nameof(operationType)),
            };
        }
    }
}