namespace ConsoleApp
{
    public static class Input
    {
        private static int _minLength = 3;
        public static string ValidteString()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Name should be not empty!");
                    continue;
                }

                if (input.Length < _minLength)
                {
                    Console.WriteLine($"Name length should be at least {_minLength} symbols!");
                    continue;
                }

                return input;
            }
        }

        public static void Return()
        {
            Console.WriteLine("To continue press ENTER...");
            Console.ReadLine();
        }
    }
}