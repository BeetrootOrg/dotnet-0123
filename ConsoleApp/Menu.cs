namespace ConsoleApp
{
    public static class Menu
    {
        private static string exitItem = "0. Exit"; 
        private static string[] _items = {"1. Create vote topic", "2. Vote", "3. Results"};

        public static void Default()
        {
            Console.Clear();
            
            foreach(string item in _items)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine(exitItem);
        }
        
        public static void Build<T>(AbstractList<T> list)
        {
            Console.Clear();
            
            foreach(IVoteItem item in list)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine(exitItem);
        }

        public static void BuildFullData<T>(AbstractList<T> list)
        {
            Console.Clear();
            
            foreach(IVoteItem item in list)
            {
                Console.WriteLine(item.FullData());
            }
            
            Console.WriteLine(exitItem);
        }

        public static void Return()
        {
            Console.WriteLine(Messages.ReturnString);
            Console.ReadLine();
        }
    }
}