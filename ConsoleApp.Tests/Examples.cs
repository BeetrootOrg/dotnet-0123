namespace ConsoleApp.Tests
{
    public static class Examples
    {
        public static Example[] Collection()
        {
            return new Example[]
            {
                new Example(a: 1, b: 1),
                new Example(a: 1, b: 3),
                new Example(a: 2, b: 2)
            };
        }
    }

    public class Example
    {
        public int A { get; private set; }
        public int B { get; private set; }
        public Example(int a, int b)
        {
            A = a;
            B = b;
        }

        public override string ToString()
        {
            return $"A: {A}; B: {B}";
        }
    }
}