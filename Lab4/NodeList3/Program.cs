
namespace Program 
{
    class Program 
    {
        static void Main() 
        {
            NodeList<string> list = new NodeList<string>();
            list.Add("vlad"); 
            list.Add("vlad1");
            list.Add("vlad2");
            list.Remove("vlad1");
            bool b = list.Contains("vlad1");
        }
    }
}