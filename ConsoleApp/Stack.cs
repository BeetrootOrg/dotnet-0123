namespace ConsoleApp
{
    public class Stack<T>
    {
        private class Element
        {
            public T Value { get; init; }
            public Element Next { get; set; }
        }

        private Element _head;
        public int Count { get; private set; }

        public void Push(T obj)
        {
            _head = new Element { Value = obj, Next = _head };
            Count++;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new ArgumentException("Stack is empty.");
            }

            T temp = _head.Value;
            _head = _head.Next;
            Count--;
            return temp;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new ArgumentException("Stack is empty.");
            }

            return _head.Value;
        }

        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        public void CopyTo(T[] arr)
        {
            int length = Count < arr.Length ? Count : arr.Length;
            Element current = _head;
            for (int i = 0; i < length; i++)
            {
                arr[i] = current.Value;
                current = current.Next;
            }
        }
    }
}