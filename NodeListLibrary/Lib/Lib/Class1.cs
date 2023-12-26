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
    public Node<T> Head {get => head;}

    private Node<T> tail ;
    public Node<T> Tail {get => tail;}

    private int count;
    public int Count { get => count; }

    public NodeList() {  }

    public override string ToString() 
    {
        string output = "";

        Node<T> node = head;

        while (node != null)
        {
            output += node.value + "\n";
            node = node.next;
        }

        return output;
    }

    public void Add(T value)
    {
        if (value == null) throw new NullReferenceException("Added value id empty");

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

    public void Remove(T value)
    {
        if (head == null) throw new NullReferenceException("Head does not exist");

        Node<T> node = head;

        Node<T> prev = null;

        while (node !=  null)
        {
            if (node.value.Equals(value))
            {
                if (node == tail){
                    prev.next = null;
                    tail = prev;

                    count--;

                    return;
                }
                if (node == head)
                {
                    head = node.next;

                    count--;

                    return;
                }
                prev.next = node.next;

                count--;

                return;
            }
            prev = node;
            
            node = node.next;
        }
        return;
    }
    public void RemoveFromTail()
    {
        if (head == null) throw new NullReferenceException("Head does not exist");

        Node<T> node = head;

        while (node.next != tail) node = node.next;
        
        node.next = null;
        tail = node;

        count--;

        return;
    }

}