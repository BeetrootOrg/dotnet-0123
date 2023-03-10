using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class OnlyEvenEnumerable : IEnumerable<int>
    {
        private readonly IEnumerable<int> _collection;

        public OnlyEvenEnumerable(IEnumerable<int> collection)
        {
            _collection = collection;
        }

        private class OnlyEvenEnumerator : IEnumerator<int>
        {
            private readonly IEnumerator<int> _enumerator;

            public OnlyEvenEnumerator(IEnumerator<int> enumerator)
            {
                _enumerator = enumerator;
            }

            public int Current { get; private set; }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                _enumerator.Dispose();
            }

            public bool MoveNext()
            {
                while (_enumerator.MoveNext())
                {
                    if (_enumerator.Current % 2 == 0)
                    {
                        Current = _enumerator.Current;
                        return true;
                    }
                }

                return false;
            }

            public void Reset()
            {
                _enumerator.Reset();
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new OnlyEvenEnumerator(_collection.GetEnumerator());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}