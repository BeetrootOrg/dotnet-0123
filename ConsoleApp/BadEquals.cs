namespace ConsoleApp
{
    public class BadEquals
    {
        public int Number { get; set; }

        public override string ToString()
        {
            return $"BadEquals {Number}";
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override bool Equals(object obj)
        {
            return false;
        }
    }
}