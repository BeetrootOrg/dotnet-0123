using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class MultiplierEnumerable : IEnumerable<int>
    {
        private readonly IEnumerable<int> _collection;
        private readonly int _multiplier;

        public MultiplierEnumerable(IEnumerable<int> collection, int multiplier)
        {
            _collection = collection;
            _multiplier = multiplier;
        }

        private class MultiplierEnumerator : IEnumerator<int>
        {
            private readonly IEnumerator<int> _enumerator;
            private readonly int _multiplier;

            public MultiplierEnumerator(IEnumerator<int> enumerator, int multiplier)
            {
                _enumerator = enumerator;
                _multiplier = multiplier;
            }

            public int Current { get; private set; }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                _enumerator.Dispose();
            }

            public bool MoveNext()
            {
                if (!_enumerator.MoveNext())
                {
                    return false;
                }

                Current = _enumerator.Current * _multiplier;
                return true;
            }

            public void Reset()
            {
                _enumerator.Reset();
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new MultiplierEnumerator(_collection.GetEnumerator(), _multiplier);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}