using ConsoleApp;
using System.Collections.Generic;

namespace Extentions
{
    
    public static class CollectionsExtentions
    {
        public static Dictionary<Tkey, List<T>> GroupBy<Tkey, T>(this IEnumerable<T> array, Func<T, Tkey> func)
        {
            Dictionary<Tkey, List<T>> dict = new Dictionary<Tkey, List<T>>();

            foreach (T item in array)
            {   
                Tkey key = func(item);

                if (!dict.ContainsKey(key))
                {
                    List<T> cell = new List<T>();
                    cell.Add(item);
                    dict.Add(key, cell);
                }

                dict[key].Add(item); 

            }

            return dict;
        }
    }
}