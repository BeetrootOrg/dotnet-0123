using System;
using System.Collections.Generic;

namespace ConsoleApp.classes
{
    public class Stack<T>
    {
        public int Count { get => ToList().Count; }

        private Element? Top;

        public void CopyTo(T[] arr)
        {
            int length = Count < arr.Length ? Count : arr.Length;
            var source = ToArray();
            for (int i = 0; i < length; i++)
            {
                arr[i] = source[i];
            }
        }

        public void Push(T obj)
        {
            var element = new Element() { Value = obj };
            if (Top == null)
            {
                Top = element;
                return;
            }
            element.Next = Top;
            Top = element;
        }

        public T Peek()
        {
            CheckInit();
            return Top.Value;
        }

        public void Clear()
        {
            Top = null;
        }

        public T Pop()
        {
            CheckInit();
            T result = Top.Value;
            Top = Top?.Next;
            return result;
        }

        public override string ToString()
        {
            return $"Count {Count}. Values={string.Join(',', ToArray())}.";
        }

        public T[] ToArray()
        {
            return ToList().ToArray();
        }

        public List<T> ToList()
        {
            var list = new List<T>();
            Element? element = Top;
            while (element != null)
            {
                list.Add(element.Value);
                element = element.Next;
            }
            return list;
        }

        private void CheckInit()
        {
            if (Top == null) throw new ArgumentNullException("Sequence not initiated");
        }

        private class Element
        {
            public Element? Next { get; set; }
            public T Value;
        }
    }
}