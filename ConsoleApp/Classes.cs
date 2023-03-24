namespace ConsoleApp
{
    public class Test
    {
        public int Number { get; init; }
        public decimal Money { get; init; }
        public string Text { get; init; }
        public bool IsActive { get; init; }
        public int[] Numbers { get; init; }
        public Inner[] Inners { get; init; }
        public object Null { get; init; }
    }

    public class Inner
    {
        public int InnerNumber { get; init; }
        public decimal InnerMoney { get; init; }
        public string InnerText { get; init; }
        public bool InnerIsActive { get; init; }
    }
}