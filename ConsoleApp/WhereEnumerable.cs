using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class WhereEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _collection;
        private readonly Predicate<T> _predicate;

        public WhereEnumerable(IEnumerable<T> collection, Predicate<T> predicate)
        {
            _collection = collection;
            _predicate = predicate;
        }

        private class WhereEnumerator : IEnumerator<T>
        {
            private readonly IEnumerator<T> _enumerator;
            private readonly Predicate<T> _predicate;

            public WhereEnumerator(IEnumerator<T> enumerator, Predicate<T> predicate)
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
                while (_enumerator.MoveNext())
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
            return new WhereEnumerator(_collection.GetEnumerator(), _predicate);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}