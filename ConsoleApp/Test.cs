using System;

namespace ConsoleApp
{
    public class Test
    {
        public int Number { get; set; }

        public override string ToString()
        {
            return $"Test {Number}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Number).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Test t &&
                Number == t.Number;
        }
    }
}