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
            if (_head == null)
            {
                _head = new Element
                {
                    Value = item
                };
            }
            else
            {
                Element element = new()
                {
                    Value = item
                };

                Element last = _head;
                for (; last.Next != null; last = last.Next)
                {
                }

                last.Next = element;
            }
        }
    }
}