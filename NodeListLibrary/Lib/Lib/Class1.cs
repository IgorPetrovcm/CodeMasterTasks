namespace NodeListLib;

public class Node<T>
{
    public T value;

    public Node<T> next ;

    public Node(T value, Node<T> next)
    {
        this.value = value;
        this.next = next;
    }
    public Node(T value)
    {
        this.value = value;
    }
    public Node()
    {

    }
}
public class NodeList<T>
{
    private Node<T> head;

    private Node<T> tail ;

    private int count;
    public int Count { get => count; }

    public NodeList() {  }

    public void Add(T value)
    {
        if (head == null) throw new NullReferenceException("Add value id empty");

        Node<T> node = new Node<T>(value);

        if (head == null)
        {
            head = node;
            head.next = node;
            tail = node;

            count++;

            return;
        }

        tail.next = node;
        tail = node;
        
        count++;
    }

}