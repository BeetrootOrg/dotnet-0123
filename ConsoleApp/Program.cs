using ConsoleApp;

Console.WriteLine("Enter math operation:");
string input = Console.ReadLine();
MathOperands operands = MathOperands.Parse(input);
IOperationFactory factory = new OperationFactory();
IOperation operation = factory.CreateOperation(operands.Operation);
Console.WriteLine($"Result is {operation.PerformOperation(operands.Operand1, operands.Operand2)}");
