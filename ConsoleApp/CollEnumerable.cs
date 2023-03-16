using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class CollEnumerable<T> : IEnumerable<T>
    {
        private IEnumerable<T> _collection;
        private Predicate<T> _predicate;

        public CollEnumerable(IEnumerable<T> collection, Predicate<T> predicate)
        {
            _collection = collection;
            _predicate = predicate;
        }

        private class CollEnumerator : IEnumerator<T>
        {
            private IEnumerator<T> _enumerator;
            private Predicate<T> _predicate;

            public CollEnumerator(IEnumerator<T> enumerator, Predicate<T> predicate)
            {
                _enumerator = enumerator;
                _predicate = predicate;
            }

            public T Current { get; private set; }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                _enumerator.Dispose();
            }

            public bool MoveNext()
            {
                while(_enumerator.MoveNext())
                {
                    if (_predicate(_enumerator.Current))
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

        public IEnumerator<T> GetEnumerator()
        {
            return new CollEnumerator(_collection.GetEnumerator(), _predicate);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
