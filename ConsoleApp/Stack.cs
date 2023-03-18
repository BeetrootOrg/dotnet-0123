using System.Text;
using System;


namespace ConsoleApp
{
    public class Stack<T>
    {
        private class Element
        {
            public T Value {get; set;}
            public Element Next {get; set;}
        }

        private Element _head;
        public int Count { get; private set; }

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
            T obj  = _head.Value;
            _head = _head.Next;
            Count--;
            return obj;
        }

        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        public T Peek()
        {
            EmptyStackException();
            return _head.Value;
        }

        public void CopyTo(T []arr)
        {
            int length = Count < arr.Length ? Count : arr.Length;
            Element current = _head;
            for (int i = 0; i < length; i++)
            {
                arr[i] = current.Value;
                current = current.Next;
            }
        }

        public bool IsNull()
        {
            return _head == null;
        }

        private void EmptyStackException()
        {
            if(IsNull())
            {
                throw new ArgumentException("Stack is empty");
            }
        }

        public override string ToString()
        {
            if (_head == null)
            {
                return string.Empty;
            }

            Element obj = _head;
            StringBuilder sb = new();
            while (obj != null)
            {
                _ = sb.Append($"{obj.Value}, ");
                obj = obj.Next;
            }
            return sb.ToString()[..^2];
        }
    }
}