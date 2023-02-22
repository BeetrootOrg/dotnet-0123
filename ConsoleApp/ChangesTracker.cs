namespace ConsoleApp
{
    public class ChangesTracker
    {
        public static int GlobalChanges { get; set; }
        public int Changes { get; set; }

        static ChangesTracker()
        {
            ResetGlobalCounter();
        }

        public void IncChanges()
        {
            ++GlobalChanges;
            ++Changes;
        }

        public static void ResetGlobalCounter()
        {
            GlobalChanges = 0;
        }
    }
}