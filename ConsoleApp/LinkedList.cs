using System.Text;

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

        public override string ToString()
        {
            if (_head == null)
            {
                return string.Empty;
            }

            Element current = _head;
            StringBuilder sb = new();
            do
            {
                _ = sb.Append($"{current.Value}, ");
                current = current.Next;
            } while (current != null);

            return sb.ToString()[..^2];
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