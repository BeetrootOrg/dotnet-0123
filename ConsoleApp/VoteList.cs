using System.Collections;

namespace ConsoleApp
{
    public abstract class VoteList<T> : IEnumerable<T>
    {
        protected List<T> _list = new List<T>();

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            _list.Add(item);
        }
    }    
}