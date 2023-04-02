using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<GroupEnumerable<TKey, TSourch>> GroupBy<TKey, TSourch>(this IEnumerable<TSourch> sourch, Func<TSourch, TKey> keySelector)
        {
            if (sourch == null || keySelector == null) throw new ArgumentNullException("I really want to sleep");
            IEnumerable<TKey> Keys = sourch.Select<TSourch, TKey>(x => keySelector.Invoke(x)).Distinct();
            foreach (TKey key in Keys)
            {
                yield return new GroupEnumerable<TKey, TSourch>(key, sourch.
                Where<TSourch>(x => keySelector.Invoke(x).Equals(key)));
            }
        }

        public static IEnumerable<TSourch> Distinct<TSourch>(this IEnumerable<TSourch> sourch)
        {
            List<TSourch> list = new();
            foreach (var item in sourch)
            {
                if (!list.Contains(item)) list.Add(item);
            }
            return list;
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> collection, Predicate<T> predicate)
        {
            return new WhereEnumerable<T>(collection, predicate);
        }

        public static IEnumerable<TOut> Select<TIn, TOut>(this IEnumerable<TIn> collection, Func<TIn, TOut> selector)
        {
            return new SelectEnumerable<TIn, TOut>(collection, selector);
        }

        public static IEnumerable<TResult> Zip<T1, T2, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, Func<T1, T2, TResult> zip)
        {
            return new ZipEnumerable<T1, T2, TResult>(first, second, zip);
        }

        public static IEnumerable<IEnumerable<T>> ChunkBy<T>(this IEnumerable<T> collection, int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Size should be positive", nameof(size));
            }

            T[] arr = new T[size];
            int index = 0;
            foreach (T item in collection)
            {
                arr[index++] = item;
                if (index >= size)
                {
                    yield return arr;
                    arr = new T[size];
                    index = 0;
                }
            }

            if (index > 0)
            {
                Array.Resize(ref arr, index);
                yield return arr;
            }
        }
    }
}