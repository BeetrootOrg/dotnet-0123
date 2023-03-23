using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class SelectEnumerable<TIn, TOut> : IEnumerable<TOut>
    {
        private readonly IEnumerable<TIn> _source;
        private readonly Func<TIn, TOut> _selector;

        public SelectEnumerable(IEnumerable<TIn> source, Func<TIn, TOut> selector)
        {
            _source = source;
            _selector = selector;
        }

        private class SelectEnumerator : IEnumerator<TOut>
        {
            private readonly IEnumerator<TIn> _source;
            private readonly Func<TIn, TOut> _selector;

            public SelectEnumerator(IEnumerator<TIn> source,
                Func<TIn, TOut> selector)
            {
                _source = source;
                _selector = selector;
            }

            public TOut Current { get; private set; }

            object IEnumerator.Current => Current;


            public void Dispose()
            {
                _source.Dispose();
            }

            public bool MoveNext()
            {
                if (!_source.MoveNext())
                {
                    return false;
                }

                Current = _selector(_source.Current);
                return true;
            }

            public void Reset()
            {
                _source.Reset();
            }
        }


        public IEnumerator<TOut> GetEnumerator()
        {
            return new SelectEnumerator(_source.GetEnumerator(), _selector);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}


