namespace ConsoleApp
{
    public class Singleton
    {
        public static readonly Singleton Instance = new();
        private Singleton() { }
    }
}