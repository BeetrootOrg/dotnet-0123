using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Name
{
    public class AverageEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _collection;
        
        public AverageEnumerable(IEnumerable<T> collection)
        {
            _collection = collection;
        }
        public class AverageEnumerator : IEnumerator<T>
        {
            private readonly IEnumerator<T> _enumerator;
        
            public AverageEnumerator(IEnumerator<T> enumerator)
            {
                _enumerator = enumerator;
            }
            public T Current {get; private set;}

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
                Current = _enumerator.Current;
                return true;
            }

            public void Reset()
            {
                _enumerator.Reset();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}