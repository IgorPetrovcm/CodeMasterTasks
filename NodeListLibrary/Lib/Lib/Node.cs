namespace NodeListLib;

public class Node<T> where T : notnull
{
    public T Value {get; private set;}

    public Node<T> Next {get; private set;}

    public Node(T value, Node<T> next)
    {
        this.Value = value;
        this.Next = next;
    }
    public Node(T value)
    {
        this.Value = value;
    }
    public Node()
    {

    }
}