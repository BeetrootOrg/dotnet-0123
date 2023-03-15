using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public static class EnumerableExtensions
    {
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
    }
}