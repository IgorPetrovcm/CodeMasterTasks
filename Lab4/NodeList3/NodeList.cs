namespace Program;
using System.Text;
public class Node<T>
{
    public T value;
    public Node<T> next;
    public Node(T value,Node<T> next) {
        this.value = value;
        this.next = next;
    }
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
        Node<T> node = new Node<T>(value, null);
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
        Node<T> node = new Node<T>(value, null);
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
                        this.count--;
                        return;
                    }
                    else {
                        head = head.next;
                        this.count--;
                        return;
                    }
                }
                else if (node == tail) {
                    prev.next = null;
                    tail = prev;
                    this.count--;
                    return;
                }
                prev.next = node.next;
                this.count--;
                return;
            }
            prev = node;
            node = node.next;
        }
    }
    public void Remove(int index) 
    {
        
        Node<T> node = head;
        Node<T> prev = null;
        int count = 0;
        while (node != null)
        {
            if (count == index) 
            {
                if (node == head) {
                    if (head.next == null) {
                        head = null;
                        tail = null;
                        this.count--;
                        return;
                    }
                    else {
                        head = head.next;
                        this.count--;
                        return;
                    }
                }
                else if (node == tail) {
                    prev.next = null;
                    tail = prev;
                    this.count--;
                    return;
                }
                prev.next = node.next;
                this.count--;
                return;
            }
            prev = node;
            node = node.next;
            count++;
        }
    }
    public bool Contains(T value) 
    {
        Node<T> node = head;
        while (node != null) 
        {
            if (node.value.Equals(value)) return true;
            node = node.next;
        }
        return false;
    } 
    public object GetIndex(T value) 
    {
        Node<T> node = head;
        int index = 0;
        while (node != null) 
        {
            if (node.value.Equals(value)) return index;
            node = node.next;
            index++;
        }
        return false;
    }
    public T GetByIndex(int index) 
    {
        Node<T> node= head;
        int count = 0;
        while (node != null) 
        {
            if (index == count) return node.value;
            node = node.next;
            count++;
        }
        return default(T);
    }
    public void Clear() 
    {
        head = null;
        tail = null;
        count = 0;
    }
    public override string ToString()
    {
        var str= new StringBuilder();
        Node<T> node = head;
        while (node != null) 
        {
            str.Append(node.value + "\n");
            node = node.next;
        }
        return str.ToString();
    }
}