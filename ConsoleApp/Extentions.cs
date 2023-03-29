using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public static class Extentions
    {
        public static Dictionary<K, List<T>> GroupBy<T, K>(this IEnumerable<T> collection, Func<T, K> func)
        {
            Dictionary<K, List<T>> dictionary = new Dictionary<K, List<T>>();

            foreach (T item in collection)
            {
                K key = func(item);

                if (!dictionary.ContainsKey(key))
                {
                    List<T> list = new List<T>();
                    list.Add(item); 
                    dictionary.Add(key, list);    
                }
                else
                {
                    dictionary[key].Add(item); 
                }
            }

            return dictionary;
        }
    }
}
