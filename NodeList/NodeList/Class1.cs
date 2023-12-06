namespace NodeList;

public class Node <T>
{
    public T value;
    public Node<T> next;
    public Node(T value=null, Node<T> next=null) {
        this.value = value;
        this.next = next;
    }
}
