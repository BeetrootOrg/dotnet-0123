using System;
using System.Collections.Generic;
namespace ConsoleApp
{
    public class IndexDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        private List<TKey> KeysList { get; set; }
        public IndexDictionary() : base()
        {
            KeysList = new List<TKey>();
        }
        
        public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            KeysList.Add(key);
        }
        public new bool TryAdd(TKey key, TValue value)
        {
            bool result = !this.ContainsKey(key);
            if (result)
            {
                Add(key,value);
            }
            return result;
        }

        public new bool Remove(TKey key)
        {
            bool result = base.Remove(key);
            KeysList.Remove(key);
            return result;
        }
        public TKey GetKeyByIndex(int index)
        {
            return KeysList[index];
        }
        public TValue GetValueByIndex(int index)
        {
            return this[GetKeyByIndex(index)];
        }
        private void CopyKeyList(out List<TKey> newList)
        {
            newList = new List<TKey>();
            foreach (var item in this.KeysList)
            {
                newList.Add(item);
            }
        }
        public List<TKey> GetKeyList()
        {
            List<TKey> list = new List<TKey>();
            CopyKeyList(out list);
            return list;
        }

        public void WriteKeyList()
        {
            List<TKey> keyList = GetKeyList();
            int count = keyList.Count;
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine($"{i+1}. {keyList[i]}");
            }
        }
    }
}