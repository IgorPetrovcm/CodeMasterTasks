 namespace Program
{
    using System;
    using System.Collections.Specialized;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Text;

    class Program
    {
        static async Task ReadAsync1(StreamReader reader) 
        {
            string text = await reader.ReadToEndAsync();
            await Task.Delay(0);
            Console.WriteLine(text);
        } 
        static void Main(string[] args)
        {
            try 
            {
                using (StreamReader reader = new StreamReader("test.txt")) 
                {
                    //first way

                    //second way
                    string line;
                    while ((line = reader.ReadLine()) != null) {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
