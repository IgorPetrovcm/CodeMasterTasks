using System;
using System.Text;
namespace Program 
{    
    class Program 
    {
        static void showBytes(byte[] bytes) 
        {
            foreach (byte b in bytes) 
            {
                System.Console.WriteLine(b.ToString("X4"));
            }
        }
        static void Main(string[] args) 
        {
            string path = @"C:\Users\Honor\Desktop\study C#\заметки\igor_petrov\Lab-3\QuadraticEqRoot2\input.txt";
            string pathOutput = @"C:\Users\Honor\Desktop\study C#\заметки\Test\QuadraticEqRoot2_test\Test1\output.txt";
            Encoding win = Encoding.UTF8;
            using (var reader = new StreamReader(path)) 
            {
                string line;
                while ((line = reader.ReadLine()) != null) 
                {
                    byte[] bytes = win.GetBytes(line);
                    showBytes (bytes);
                    System.Console.WriteLine("\n\n");
                }
            }
        }
    } 
}
