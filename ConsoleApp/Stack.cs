using System.Text;

namespace GenericStack
{
    public class Stack <T>
    {
        private class Element
        {
            public T Value { get; init; }
            public Element Next { get; set; }
        }
        public int Count { get; private set; }
        private Element _head;
        
        public void Puch(T item)
        {
            _head = new Element
            {
                Value = item,
                Next = _head
            };
            Count++;
        }
            
        public T Pop()
        {
            if(_head == null)
            {
                throw new System.Exception ($"Stack is empty");
            }
            T pop = _head.Value;
            _head = _head.Next;
            Count--;
            return pop;
        }

        public T Peek()
        {
            if(_head == null)
            {
                throw new System.Exception ($"Stack is empty");
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
            int length;
            if (arr.Length >= Count)
            {
                length = Count;
            }
            else
            {
                length = arr.Length;
            }

            Element current = _head;
            for (int i = 0; i < Count; i++)
            {
                arr[i] = current.Value;
                current = current.Next;
            }
        }
    }
}
