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