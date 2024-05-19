using System.Collections;

namespace KrakeAlgorithms.DataStructures;

public sealed class MyCircularLinkedList<T> : LinkedList<T>
{
    public new IEnumerator<T> GetEnumerator() => new MyCircularEnumerator<T>(this);
}

internal sealed class MyCircularEnumerator<T>(LinkedList<T> list) : IEnumerator<T>
{
    private LinkedListNode<T>? _current;
    
    public T Current => _current is not null ? _current.Value : default!;
    object IEnumerator.Current => Current!;
    
    public bool MoveNext()
    {
        if (_current is null)
        {
            _current = list.First;
            return _current is not null;
        }

        _current = _current.Next ?? _current!.List?.First;
        return true;
    }

    public void Reset()
    {
        _current = null;
    }

    public void Dispose()
    {
    }
}

public static class MyCircularLinkedListExtensions
{
    public static LinkedListNode<T>? Next<T>(this LinkedListNode<T> n) =>
        n is { List: not null } ? n.Next ?? n.List.First : null;

    public static LinkedListNode<T>? Prev<T>(this LinkedListNode<T> n) =>
        n is { List: not null } ? n.Previous ?? n.List.Last : null;
}