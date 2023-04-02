using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class GroupEnumerable<Tkey, TSourch> : IEnumerable<TSourch>
    {
        public Tkey Key { get; private set; }
        private readonly IEnumerable<TSourch> _sourch;

        public GroupEnumerable(Tkey key, IEnumerable<TSourch> sourch)
        {
            Key = key;
            _sourch = sourch;
        }

        public IEnumerator<TSourch> GetEnumerator()
        {
            return _sourch.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}