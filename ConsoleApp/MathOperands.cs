using System.Text;

namespace ConsoleApp
{
    public enum OperationType
    {
        Unknown,
        Add,
        Subtract,
        Multiply,
        Divide,
        Pow
    }

    public class MathOperands
    {
        public int Operand1 { get; init; }
        public int Operand2 { get; init; }
        public OperationType Operation { get; init; }

        public static MathOperands Parse(string input)
        {
            int operand1 = 0, operand2;
            OperationType operation = OperationType.Unknown;

            StringBuilder sb = new();
            foreach (char symbol in input)
            {
                if (symbol is '+' or '-' or '*' or '/' or '^')
                {
                    operation = symbol switch
                    {
                        '+' => OperationType.Add,
                        '-' => OperationType.Subtract,
                        '*' => OperationType.Multiply,
                        '/' => OperationType.Divide,
                        '^' => OperationType.Pow,
                        _ => throw new ArgumentException("Unknown value")
                    };

                    operand1 = int.Parse(sb.ToString());
                    _ = sb.Clear();
                }
                else
                {
                    _ = sb.Append(symbol);
                }
            }

            operand2 = int.Parse(sb.ToString());
            return new MathOperands
            {
                Operand1 = operand1,
                Operand2 = operand2,
                Operation = operation
            };
        }
    }
}