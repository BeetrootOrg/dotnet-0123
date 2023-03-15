using System.Collections;

namespace ConsoleApp
{
    public abstract class VoteList<IVoteItem> : IEnumerable<IVoteItem>
    {
        protected List<IVoteItem> _list = new List<IVoteItem>();

        public IEnumerator<IVoteItem> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(IVoteItem item)
        {
            _list.Add(item);
        }
    }    
}