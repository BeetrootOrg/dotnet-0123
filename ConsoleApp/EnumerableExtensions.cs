using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    internal static class IEnumerableExtensions
    {
        public static IEnumerable<IGrouping<TKey, TSource>> GroupByEnumerable<TSource, TKey>(this IEnumerable<TSource> collection, Func<TSource, TKey> keySelector) where TKey : notnull
        {
            if (collection.Count() == 0)
            {
                return new List<IGrouping<TKey, TSource>>();
            }

            IEnumerable<TKey> selectedKeys = collection.Select(keySelector);
            selectedKeys = selectedKeys.Distinct();

            List<IGrouping<TKey, TSource>> result = new List<IGrouping<TKey, TSource>>(0);
            foreach (TKey key in selectedKeys)
            {
                List<TSource> list = new List<TSource>();
                foreach (TSource item in collection)
                {
                    if (keySelector(item).Equals(key))
                    {
                        list.Add(item);
                    }
                }
                result.Add(new Grouping<TKey, TSource>(key, list));
            }
            return result;
        }
    }
}