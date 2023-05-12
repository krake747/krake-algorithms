namespace KrakeAlgorithms.Lib.DataStructures;

public sealed class MyQueue<T> : IMyQueue<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;
    public int Length { get; set; }

    public MyQueue()
    {
    }
    
    public void Enqueue(T item)
    {
        var node = new Node<T>
        {
            Value = item
        };

        Length++;
        if (_tail is null)
        {
            _head = node;
            _tail = node;
            return;
        }

        _tail.Next = node;
        _tail = node;
    }

    public T? Dequeue()
    {
        if (_head is null)
        {
            return default;
        }

        Length--;
        var head = _head;
        _head = _head.Next;

        if (Length is 0)
        {
            _tail = default;
        }

        return head.Value;
    }

    public T? Peek()
    {
        return _head is not null ? _head.Value : default;
    }
}

public sealed class Node<T>
{
    public T? Value { get; init; }
    public Node<T>? Next { get; set; }
}

public interface IMyQueue<T>
{
    int Length { get; set; }
    void Enqueue(T item);
    T? Dequeue();
    T? Peek();
}

