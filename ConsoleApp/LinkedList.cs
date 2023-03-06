namespace ConsoleApp
{
    public class LinkedList<T>
    {
        private class Element
        {
            public T Value { get; init; }
            public Element Next { get; set; }
        }

        private Element _head;
        public int Length { get; private set; }

        public void Add(T item)
        {
            Element element = new()
            {
                Value = item
            };

            if (_head == null)
            {
                _head = element;
            }
            else
            {
                Element last = Last();
                last.Next = element;
            }

            ++Length;
        }

        public void Clear()
        {
            _head = null;
            Length = 0;
        }

        public T[] ToArray()
        {
            T[] arr = new T[Length];

            Element current = _head;
            for (int i = 0; i < Length; i++)
            {
                arr[i] = current.Value;
                current = current.Next;
            }

            return arr;
        }

        public override string ToString()
        {
            return string.Join(", ", ToArray());
        }

        private Element Last()
        {
            Element last = _head;
            while (last.Next != null)
            {
                last = last.Next;
            }

            return last;
        }
    }
}