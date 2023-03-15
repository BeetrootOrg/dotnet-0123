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
        
        public static void Build<T>(VoteList<T> list)
        {
            Console.Clear();
            
            foreach(IVoteItem item in list)
            {
                Console.WriteLine(item.ShortTitle);
            }
            
            Console.WriteLine(exitItem);
        }

        public static void BuildFull<T>(VoteList<T> list)
        {
            Console.Clear();
            
            foreach(IVoteItem item in list)
            {
                Console.WriteLine(item.FullTitle);
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