namespace ConsoleApp;

public class Stack<T>
{
    private List<T> items = new List<T>();

    public void Push(T item)
    {
        items.Add(item);
    }

    public T Pop()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        T item = items[items.Count - 1];
        items.RemoveAt(items.Count - 1);
        return item;
    }

    public void Clear()
    {
        items.Clear();
    }

    public int Count
    {
        get { return items.Count; }
    }

    public T Peek()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return items[items.Count - 1];
    }

    public void CopyTo(T[] array, int index)
    {
        items.CopyTo(array, index);
    }
}
