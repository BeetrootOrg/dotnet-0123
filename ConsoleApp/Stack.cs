namespace ConsoleApp
{
    public class Stack<T>
    {
        private class Element
        {
            public T? Value { get; set; }
            public Element? Next { get; set; }
        }

        private Element? _top;
        public int Count { get; private set; }

        public void Push(T value)
        {
            Element top = new Element
            {
                Value = value
            };

            top.Next = _top;
            _top = top;
            Count++;
        }

        public T? Pop()
        {
            if (_top != null)
            {
                Element? top = _top;
                _top = _top.Next;
                Count--;
                
                return top.Value;
            }

            return default(T);
        }

        public void Clear()
        {
            _top = null;
            Count = 0;
        }

        public T? Peek()
        {
            return _top != null ? _top.Value : default(T);
        }

        public void CopyTo(T[] arr)
        {
            int length = arr.Length >= Count ? Count : arr.Length;
            Element? top = _top;
            
            for (int i = 0; i < length; i++)
            {
                if (top != null && top.Value != null)
                {
                    arr[i] = top.Value;
                }

                top = _top?.Next;    
            }
        }
    }
}