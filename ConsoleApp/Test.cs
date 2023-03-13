namespace ConsoleApp
{
    public delegate int AddOverflowDelegate(long result);
    public delegate void AddSuccessDelegate(int result);

    public class Test
    {
        public static int Add(int a, int b,
            AddOverflowDelegate overflow,
            AddSuccessDelegate success)
        {
            long result = (long)a + b;
            if (result > int.MaxValue)
            {
                result = overflow(result);
            }

            int converted = (int)result;

            success(converted);
            return converted;
        }
    }
}