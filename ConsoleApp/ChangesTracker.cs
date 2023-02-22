namespace ConsoleApp
{
    public class ChangesTracker
    {
        public int Changes { get; set; }

        public void IncChanges()
        {
            ++Changes;
        }
    }
}