namespace ConsoleApp
{
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