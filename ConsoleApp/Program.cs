Test _ = new Test();
// COMPILATION ERROR
// test.Method();

IA test2 = new Test();
test2.Method(); // IA.Method

IB test3 = new Test();
test3.Method(); // IB.Method

internal interface IA
{
    void Method();
}

internal interface IB
{
    void Method();
}

internal class Test : IA, IB
{
    void IA.Method()
    {
        Console.WriteLine("IA.Method");
    }

    void IB.Method()
    {
        Console.WriteLine("IB.Method");
    }
}