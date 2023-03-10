using System.Text;
using System;
namespace ConsoleApp
{
    public class Stack<T>
    {
        private class Element
        {
            public T Value { get; set; }
            public Element Next { get; set; }
        }
        private Element _head;
        public int Count{get; private set;}

        public void Push(T obj)
        {
            _head = new Element
            {
                Value = obj,
                Next = _head
            };
            Count++;
        }
        public T Pop()
        {
            EmptyStackException();
            T value = _head.Value;
            _head = _head.Next;
            Count--;
            return value;
        }
        public T Peek()
        {
            EmptyStackException();
            return _head.Value;
        }

        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            Element obj = _head;
            for (int i = 0; i < Count; i++)
            {
                array[i] = obj.Value;
                obj = obj.Next;
            }
            return array;
        }
        public bool IsEmpty()
        {
            return _head==null;
        }

        private void EmptyStackException()
        {
            if (IsEmpty())
            {
                throw new ArgumentException("Stack is empty! You cannot get any value!");
            }
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                return string.Empty;
            }

            StringBuilder sb = new();
            Element obj = _head;
            while (obj != null)
            {
                sb.Append(obj.Value + ", ");
                obj = obj.Next;
            }
            return sb.ToString()[..^2];
        }
    }
}