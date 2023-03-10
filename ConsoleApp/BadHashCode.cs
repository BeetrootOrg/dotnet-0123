namespace ConsoleApp
{
    public class BadHashCode
    {
        private static int s_hashCode;

        public int Number { get; set; }

        public override string ToString()
        {
            return $"BadHashCode {Number}";
        }

        public override int GetHashCode()
        {
            return s_hashCode++;
        }

        public override bool Equals(object obj)
        {
            return obj is BadHashCode t &&
                Number == t.Number;
        }
    }
}