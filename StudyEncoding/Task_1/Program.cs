 namespace Program
{
    using System;
    using System.Text;    

    class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello World!";
            Encoding encoding = Encoding.Unicode;
            Encoding ascii = Encoding.ASCII;

            byte[] bytes = encoding.GetBytes(text);
            byte[] asciiByte = Encoding.Convert(encoding,ascii,bytes);

            int charArrSize = ascii.GetCharCount(asciiByte, 0, asciiByte.Length);
            char[] asciiChar = new char[charArrSize];
            ascii.GetChars(asciiByte, 0, charArrSize, asciiChar, 0);
            string asciiStr = new string(asciiChar); 
            
            Console.WriteLine(asciiStr);
        }
    }
}
