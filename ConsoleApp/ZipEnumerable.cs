using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class ZipEnumerable<T1, T2, TResult> : IEnumerable<TResult>
    {
        private readonly IEnumerable<T1> _first;
        private readonly IEnumerable<T2> _second;
        private readonly Func<T1, T2, TResult> _zip;

        public ZipEnumerable(IEnumerable<T1> first,
            IEnumerable<T2> second,
            Func<T1, T2, TResult> zip)
        {
            _first = first;
            _second = second;
            _zip = zip;
        }

        private class ZipEnumerator : IEnumerator<TResult>
        {
            private readonly IEnumerator<T1> _first;
            private readonly IEnumerator<T2> _second;
            private readonly Func<T1, T2, TResult> _zip;

            public ZipEnumerator(IEnumerator<T1> first,
                IEnumerator<T2> second,
                Func<T1, T2, TResult> zip)
            {
                _first = first;
                _second = second;
                _zip = zip;
            }

            public TResult Current { get; private set; }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                _first.Dispose();
                _second.Dispose();
            }

            public bool MoveNext()
            {
                if (!_first.MoveNext() || !_second.MoveNext())
                {
                    return false;
                }

                Current = _zip(_first.Current, _second.Current);
                return true;
            }

            public void Reset()
            {
                _first.Reset();
                _second.Reset();
            }
        }

        public IEnumerator<TResult> GetEnumerator()
        {
            return new ZipEnumerator(_first.GetEnumerator(),
                _second.GetEnumerator(),
                _zip);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}