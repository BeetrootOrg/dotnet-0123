using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public static class CollExtentions
    {
        public static Dictionary<int, List<Example>> GroupBy(this IEnumerable<Example> collection, Func<Example, int> func)
        {
            Dictionary<int, List<Example>> dictionary = new Dictionary<int, List<Example>>();
            
            foreach(int key in new CollEnumerable<Example, int>(collection, func))
            {
                if (!dictionary.ContainsKey(key))
                {
                    dictionary.Add(key, buildValue(collection, key));
                }    
            }

            return dictionary;
        }

        public static List<Example> buildValue(IEnumerable<Example> collection, int key)
        {
            List<Example> list = new List<Example>();
            foreach (var item in collection)
            {
                if (key.Equals(item.A))
                {
                    list.Add(item);
                } 
            }

            return list;
        } 
    }
}