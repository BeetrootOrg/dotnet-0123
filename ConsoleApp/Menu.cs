namespace ConsoleApp
{
    public static class Menu
    {
        private static string[] _items = {"1. Create vote topic", "2. Vote", "3. Results", "0. Exit"};

        public static void Show()
        {
            Console.Clear();
            foreach(string item in _items)
            {
                Console.WriteLine(item);
            }
        }

        public static void Return()
        {
            Console.WriteLine("To continue press ENTER...");
            Console.ReadLine();
        }
    }
}