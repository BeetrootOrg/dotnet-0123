using ConsoleApp;

static IOperation CreateOperation(OperationType operationType)
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

Console.WriteLine("Enter math operation:");
string input = Console.ReadLine();
MathOperands operands = MathOperands.Parse(input);
IOperation operation = CreateOperation(operands.Operation);
Console.WriteLine($"Result is {operation.PerformOperation(operands.Operand1, operands.Operand2)}");