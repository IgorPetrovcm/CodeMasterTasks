using System.ComponentModel;
using System.Net.Http.Headers;

namespace NodeListLib;

public class NodeList<T>
{
    
    public Node<T> Head {get; private set;}

    public Node<T> Tail {get; private set;}

    public int Count { get; private set;}

    /*public override string ToString() 
    {
        string output = "";

        Node<T> node = head;

        while (node != null)
        {
            output += node.Value + "\n";
            node = node.Next;
        }

        return output;
    }*/

    public void Add(T value)
    {
        Node<T> node = new Node<T>(value);
        if (Head == null)
        {
            Head = node;

            Head.AssignNext(node);

            Tail = node;

            Count++;

            return;
        }

        Tail.AssignNext(node);

        Tail = node;
        
        Count++;
    }

    /*public void Remove(T value)
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

    public static NodeList<T> UploadUsingArray(T[] arr)
    {
        if (arr == null) throw new NullReferenceException("Upload array is empty");

        NodeList<T> nodes = AddedElementsFromI(arr);

        return nodes;
    }
    public static NodeList<T> UploadUsingList(IList<T> list)
    {
        if (list == null) throw new NullReferenceException("Upload list is empty");

        NodeList<T> nodes = AddedElementsFromI(list);

        return nodes;
    }
    public static NodeList<T> UploadUsingEnumerable(IEnumerable<T> elements)
    {
        if (elements == null) throw new NullReferenceException("Upload struct is empty");

        NodeList<T> nodes = AddedElementsFromI(elements);

        return nodes; 
    }

    public static NodeList<T> AddedElementsFromI(IEnumerable<T> elements)
    {
        NodeList<T> nodes = new NodeList<T>();

        foreach (var element in elements)
        {
            nodes.Add(element);
        }

        return nodes;
    }*/

}