using System;
namespace Program 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            SortedList<int,string> list = new SortedList<int,string>(20);
            list.Add(25,"Tomato");
            list.Add(18,"Maroon");
            list.Add(120,"Red");
            list.Add(2,"Blue");
            
            ICollection<int> keys = list.Keys;
            foreach (int key in keys) 
            {
                System.Console.WriteLine(key);
            }
        }
    }
}