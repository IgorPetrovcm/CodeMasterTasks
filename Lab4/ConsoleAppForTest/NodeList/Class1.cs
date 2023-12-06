namespace NodeList;

public class Node<T>
{
    T value;
    Node<T> next;
    public Node(T value) {
        this.value = value;
    }
}
public class NodeList<T> 
{
    Node<T> head;
    Node<T> tail;
    int count;
    public void Add(T value) 
    {
        Node<T> node = new Node<T>(value);
        if (head == null) 
        {
            head = node;

        }
    }
}
