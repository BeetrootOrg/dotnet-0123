namespace ConsoleApp
{
    public abstract class AbstractList<T>
    {
        protected List<T> _list = new List<T>();
        
        public void Add(T item)
        {
            _list.Add(item);
        }

        public void Menu()
        {
            foreach(T item in _list)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine("0. Exit");
        } 
    }
}