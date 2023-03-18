namespace ConsoleApp
{
    public class Stack<T>
    {

        public int count = 0;
        private class _Element
        {
            public T item {get; set;}
            public _Element next {get; set;}

        }

        private _Element _top;

        public void Push(T a)
        {
            count++;
            _top = new _Element
            {
                item = a,

                next = _top

            };
        }
        public T Pop()
        {
            if (count != 0)
            {
                count--;
                T a = _top.item;
                _top = _top.next;
                return a;
            }
            throw new Exception("Stack is empty");
        }

        public void Clear()
        {
            count = 0;
            _top = null;
        }

        public T Peek()
        {
            if (_top != null)
            {
                return _top.item;
            }

            throw new Exception("Stack is empty");
        }

        public T[] CopyTo(T []a)
        {
            _Element b = _top;

            for (int i = 0; i < count; i++)
            {
                a[i] = _top.item;
                _top = _top.next;
            }
            _top = b;
            return a;
        }

        public bool IsEmpty(T a)
        {
            return a == null;
        }
    }
}