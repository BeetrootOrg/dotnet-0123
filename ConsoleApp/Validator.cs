namespace ConsoleApp
{
    public static class Validator
    {
        private static int _minLength = 3;

        public static string GetInput()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine(Messages.EmptyString);
                    continue;
                }

                if (input.Length < _minLength)
                {
                    Console.WriteLine($"{Messages.ShortString} {_minLength}"); 
                    continue;
                }

                return input;
            }
        }
    }
}
