namespace ConsoleApp
{
    public class Cache
    {
        public static readonly Cache Instane = new();
        public int[] _veryHardData {get;}
        private Cache()
        {
            Thread.Sleep(5000);
            _veryHardData = new[] { 42 };
        }
    }
}