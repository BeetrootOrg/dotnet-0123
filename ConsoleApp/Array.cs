namespace ConsoleApp
{ 
    public struct SubArray
    {
        public int A {get;init;}
        public int B {get;init;}
        public SubArray(int a, int b)
        {
            A = a;
            B = b;
        }
        public override string ToString()
        {
            return $"{{{A}: {B}}}";
        }
    }
}