namespace ConsoleApp
{
    public class Element
    {
        public int A {get; private set;}
        public int B {get; private set;}

        public Element(int a1, int b1)
        {
            A = a1;
            B = b1;
        }
        public override string ToString()
        {
           return $"{{a:{A}, b:{B}}}";
        }
    }
}