
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

            check = list.Contains("vlad123");
            check = list.Contains("vlad");

            list.Remove("vlad232");
            list.Remove("vlad");
            list.Remove(0);

            list.AddToBegin("vlad1");

            System.Console.WriteLine(list.ToString());
            
            list.Clear();
            //РАБОТАЕЕЕТ
        }
    }
}