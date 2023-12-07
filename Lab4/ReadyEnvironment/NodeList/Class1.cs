namespace NodeList;

public class Node<T>
{
    public T value;
    public Node<T> next;
    public Node(T value,Node<T> next) {
        this.value = value;
    }
    public Node(T value) {}
    public Node() {}
}
public class NodeList<T> 
{
    Node<T> head;
    Node<T> tail;
    int count;
    public int Count {get {return count;}}
    public NodeList() {}
    
    public void Add(T value) 
    {
        Node<T> node = new Node<T>(value);
        if (head == null) 
        {
            head = node;
            head.next = node;
            tail = node;
            tail.next = node;
            count++;
            return;
        }
        tail.next = node;
        tail = node;
        count++;
    }
    public void AddToBegin(T value) 
    {        
        if (head == null)
        {
            Add(value);
            return;
        }
        Node<T> node = new Node<T>(value);
        node.next = head;
        head = node;
    }
    public void Remove(T value) 
    {
        Node<T> node = head;
        Node<T> prev = null;
        while (node != null)
        {
            if (node.value.Equals(value)) 
            {
                if (node == head) {
                    if (head.next == null) {
                        head = null;
                        tail = null;
                        return;
                    }
                    else {
                        head = head.next;
                        return;
                    }
                }
                else if (node == tail) {
                    prev.next = null;
                    tail = prev;
                    return;
                }
                prev.next = node.next;

            }
            prev = node;
            node = node.next;
        }
    }
}