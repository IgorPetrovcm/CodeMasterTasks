
namespace Program 
{
    class Program 
    {
        static void Main() 
        {
            bool check;

            NodeList<string> list = new NodeList<string>();
            list.Add("vlad"); 
            list.Add("vlad1");
            list.Add("vlad2");
            System.Console.WriteLine(list.GetIndex("vlad2"));
            System.Console.WriteLine(list.GetByIndex(0));
            list.Remove("vlad232");
            check = list.Contains("vlad123");
            check = list.Contains("vlad");
            list.Remove("vlad");
        }
    }
}