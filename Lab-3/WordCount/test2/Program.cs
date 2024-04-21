using System;
using System.Text;
namespace Program 
{
    class Program 
    {
        static void Main() 
        {
            string path = @"C:\Users\Honor\Desktop\study C#\заметки\igor_petrov\Lab-3\WordCount\Data\Начало.txt";
            byte[] bytes = File.ReadAllBytes(path);
            Encoding utf = Encoding.UTF8;      

            byte[] newBytes = Encoding.Convert(Encoding.GetEncoding(1252), utf, bytes);
            char[] charsText = new char[utf.GetCharCount(newBytes,0, newBytes.Length)];   
            utf.GetChars(newBytes, 0, newBytes.Length, charsText, 0);
            System.Console.WriteLine(new string(charsText));              
        }
    }
}