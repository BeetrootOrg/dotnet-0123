using System;

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
            Insert(item, Length);
        }

        public void Clear()
        {
            _head = null;
            Length = 0;
        }

        public void RemoveAt(int position)
        {
            if (position < 0 || position >= Length)
            {
                throw new IndexOutOfRangeException($"Index is outside of list");
            }

            if (position == 0)
            {
                _head = _head.Next;
            }
            else
            {
                Element current = _head;
                for (int i = 0; i < position - 1; i++)
                {
                    current = current.Next;
                }

                current.Next = current.Next.Next;
            }

            --Length;
        }

        public void Insert(T item, int position)
        {
            if (position < 0 || position > Length)
            {
                throw new IndexOutOfRangeException($"Index is outside of list");
            }

            Element element = new()
            {
                Value = item
            };

            if (position == 0)
            {
                element.Next = _head;
                _head = element;
            }
            else
            {
                Element current = _head;
                for (int i = 0; i < position - 1; i++)
                {
                    current = current.Next;
                }

                element.Next = current.Next;
                current.Next = element;
            }

            ++Length;
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

        public void CopyTo(T[] arr)
        {
            int length = Length < arr.Length ? Length : arr.Length;
            Element current = _head;
            for (int i = 0; i < length; i++)
            {
                arr[i] = current.Value;
                current = current.Next;
            }
        }

        public override string ToString()
        {
            return string.Join(", ", ToArray());
        }
    }
}