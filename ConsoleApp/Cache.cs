namespace ConsoleApp
{
    public class Cache
    {
        public static readonly Cache Instane = new();
        public int[] VeryHardData { get; }

        private Cache()
        {
            Thread.Sleep(5000);
            VeryHardData = new[] { 42 };
        }
    }
}