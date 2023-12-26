namespace ConsoleApp;
using NodeListLib;


class Program 
{
    static void Main()
    {
        NodeList<int> nodes = new NodeList<int>();

        for (int i = 0; i < 10; i++)
        {
            nodes.Add(i);
        }

        System.Console.WriteLine(nodes.Count);

        System.Console.WriteLine(nodes.ToString());

        nodes.Remove(0);
        nodes.Remove(1);
        nodes.Remove(9);

        System.Console.WriteLine(nodes.Count + "\n" + nodes.ToString());

        nodes.RemoveFromTail();

        System.Console.WriteLine(nodes.ToString());
    }
}