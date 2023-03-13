namespace ConsoleApp.Helpers
{
    public static class Helper
    {
        public static int? IsValueIntAndInRange(string? value, int min, int max)
        {
            int? val = IsValueInt(value);
            if (val != null && val >= min && val <= max)
                return val;
            return null;
        }

        public static int? IsValueIntAndInRange(string? value, List<int> list)
        {
            int? val = IsValueInt(value);
            if (val != null && list.Contains((int)val))
                return val;
            return null;
        }


        public static int? IsValueInt(string? value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            int result;
            if (!int.TryParse(value, out result)) return null;
            return result;
        }
    }
}