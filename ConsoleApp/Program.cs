using System.Collections.Generic;

using ConsoleApp;

TestClass[] collection = new[]
{
    new TestClass
    {
        A = 1,
        B = "a"
    },
    new TestClass
    {
        A = 2,
        B = "a"
    },
    new TestClass
    {
        A = 1,
        B = "b"
    },
};

IDictionary<int, IEnumerable<TestClass>> result1 = collection.GroupBy(x => x.A);
IDictionary<string, IEnumerable<TestClass>> result2 = collection.GroupBy(x => x.B);

internal class TestClass
{
    public int A { get; set; }
    public string B { get; set; }
}