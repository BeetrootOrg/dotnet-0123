using System;

namespace ConsoleApp
{
    public class Stack<T>
    {
        private class StackItem
        {
            public T Item { get; init; }
            public StackItem Next { get; init; }
        }

        private StackItem _head;

        public int Count { get; private set; }

        public void Push(T item)
        {
            _head = new StackItem
            {
                Item = item,
                Next = _head
            };

            ++Count;
        }

        public T Pop()
        {
            AssertNotEmpty();

            StackItem current = _head;
            _head = _head.Next;
            --Count;

            return current.Item;
        }

        public T Peek()
        {
            AssertNotEmpty();
            return _head.Item;
        }

        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        public void CopyTo(T[] arr)
        {
            int length = arr.Length > Count ? Count : arr.Length;
            StackItem current = _head;
            for (int i = 0; i < length; i++)
            {
                arr[i] = current.Item;
                current = current.Next;
            }
        }

        private void AssertNotEmpty()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Stack is empty!");
            }
        }
    }
}