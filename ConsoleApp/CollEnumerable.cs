using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class CollEnumerable<T, K> : IEnumerable<object>
    {
        private IEnumerable<T> _collection;
        private Func<T, K> _func;
        public CollEnumerable(IEnumerable<T> collection, Func<T, K> func)
        {
            _collection = collection;
            _func = func;
        }

        private class CollEnumerator : IEnumerator<object>
        {
            IEnumerator<T> _enumerator;
            Func<T, K> _func;
            public CollEnumerator(IEnumerator<T> enumerator, Func<T, K> func)
            {
                _enumerator = enumerator;
                _func = func;
            }
            public object Current { get; private set; }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                _enumerator.Dispose();
            }

            public bool MoveNext()
            {
                while(_enumerator.MoveNext())
                {
                    Current = _func(_enumerator.Current);
                    return true;
                }
                return false;    
            }

            public void Reset()
            {
                _enumerator.Reset();
            }
        }

        public IEnumerator<object> GetEnumerator()
        {
            return new CollEnumerator(_collection.GetEnumerator(), _func);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
