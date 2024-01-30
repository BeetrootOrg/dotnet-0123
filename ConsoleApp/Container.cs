using System;
using System.Collections.Generic;

namespace GenericContainer
{
    public class Container<T>
    {
        private readonly List<T> _items;

        public Container(List<T> items)
        {
            _items = items;
        }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public T GetType(int index)
        {
            if(index < 0 || index >= _items.Count)
            throw new IndexOutOfRangeException("Index is out of range");

            return _items[index];
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public int Count
        {
            get {return _items.Count;}
        }

        public void Clear()
        {
            _items.Clear();
        }
    }    
}