using System;

namespace ConsoleApp
{
    public class Stack<T>
    {
        private class StackItem
        {
            public T Value { get; init; }
            public StackItem Next { get; init; }
        }

        private StackItem _stackItem;
        public int Count { get; private set; }

        public void Push(T value)
        {
            StackItem stackItem = new()
            {
                Value = value,
                Next = _stackItem
            };
            _stackItem = stackItem;
            ++Count;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            StackItem item = _stackItem;
            _stackItem = _stackItem.Next;
            --Count;

            return item.Value;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return _stackItem.Value;
        }
    }
}
