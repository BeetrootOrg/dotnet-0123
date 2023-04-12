using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp
{
    internal class Grouping<TKey, TElement> : IGrouping<TKey, TElement>, IEnumerable<TElement>
    {
        public TKey Key { get; }
        private IEnumerable<TElement> _group;
        public Grouping(TKey key, IEnumerable<TElement> group)
        {
            if (group is null)
            {
                throw new ArgumentException("Group can be empty, can contain some element, but it can't be null.");
            }

            Key = key;
            _group = group;
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            return _group is not null ? _group.GetEnumerator()
                                      : throw new ArgumentException("Group is null.");

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}