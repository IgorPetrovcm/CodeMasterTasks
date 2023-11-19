 namespace Program
{
    using System;
    using System.Text;
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello World!";
            Encoding unicode = Encoding.Unicode;
            byte[] bytes = unicode.GetBytes(text);
            foreach (byte c in bytes) {
                Console.Write(c + " ");
            }
            Console.WriteLine();

            Encoding ascii = Encoding.UTF7;
            Console.WriteLine(ascii.GetString(bytes)); 

            
        }
    }
}
