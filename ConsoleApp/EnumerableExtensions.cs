using System.Linq;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public static class EnumerableExtensions
    {
        public static IDictionary<TKey, IEnumerable<TSource>> GroupByEnumerable<TSource, TKey>(this IEnumerable<TSource> collection,
            Func<TSource, TKey> keySelector) where TKey : notnull
        {
            if (collection == null)
            {
                throw new NullReferenceException("Collection should not be null.");
            }

            if (!collection.Any())
            {
                return new Dictionary<TKey, IEnumerable<TSource>>();
            }

            IDictionary<TKey, IEnumerable<TSource>> result = new Dictionary<TKey, IEnumerable<TSource>>();
            foreach (TSource item in collection)
            {
                TKey key = keySelector(item);
                if (!result.ContainsKey(key))
                {
                    result[key] = new List<TSource>();
                }
                ((IList<TSource>)result[key]).Add(item);
            }

            return result;
        }
    }
}