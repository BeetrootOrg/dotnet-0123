using System.Collections.Generic;

using MessagePack;

namespace ConsoleApp
{
    public class Test
    {
        public int Number { get; init; }
        public decimal Money { get; init; }
        public string Text { get; init; }
        public bool IsActive {get; init; }
        public int[] Numbers { get; init; } 
        public Inner[] Inners { get; init; }
        public object Null { get; init; }
    }

    public class Inner
    {
        public int InnerNumber { get; init; }
        public decimal InnerMoney { get; init; }
        public string InnerText { get; init; }
        public bool InnerIsActive {get; init; }
    }
}

[MessagePackObject]
public class MyClass
{
    [Key(0)]
    public int Age { get; set; }

    [Key(1)]
    public string FirstName { get; set; }

    [Key(2)]
    public string LastName { get; set; }
}