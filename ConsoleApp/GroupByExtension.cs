using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public static class GroupByExtension
    {
        public static Dictionary<TKey,List<TSource>> GroupBy<TKey,TSource>(this IEnumerable<TSource> collection, Func<TSource,TKey> selector)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection), "You cannot group null collection!");
            }
            Dictionary<TKey,List<TSource>> output = new Dictionary<TKey, List<TSource>>();
            HashSet<TKey> keys = new HashSet<TKey>();
            foreach (var item in collection)
            {
                keys.Add(selector(item));
            }
            foreach (var item in keys)
            {
                output.Add(item, new List<TSource>());
            }
            foreach (var item in collection)
            {
                output[selector(item)].Add(item);
            }
            return output;
        }
    } 
}