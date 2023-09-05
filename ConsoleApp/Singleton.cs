namespace ConsoleApp
{
    public class Singleton
    {
        //public static readonly Singleton Instance = new();
        
        //private Singleton() { }
        public static readonly Singleton Instance;
        static Singleton()
        {
            Instance = new Singleton();
        }

        private Singleton() {}
    }
}