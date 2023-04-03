using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public static class EnumerableExtensions
    {
        public static IDictionary<TKey, IEnumerable<TItem>> GroupBy<TItem, TKey>(this IEnumerable<TItem> collection,
            Func<TItem, TKey> func)
        {
            IDictionary<TKey, IEnumerable<TItem>> result = new Dictionary<TKey, IEnumerable<TItem>>();
            foreach (TItem item in collection)
            {
                TKey key = func(item);
                if (!result.ContainsKey(key))
                {
                    result[key] = new List<TItem>();
                }

                ((List<TItem>)result[key]).Add(item);
            }

            return result;
        }
    }
}