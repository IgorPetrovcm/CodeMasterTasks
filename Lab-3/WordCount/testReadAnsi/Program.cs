using System;
using System.Text;
namespace Program;
class Program 
{
    static void Main() 
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        string text = File.ReadAllText(@"C:\Users\Honor\Desktop\study C#\заметки\igor_petrov\Lab-3" + 
        @"\WordCount\Data\Начало.txt",Encoding.GetEncoding(1251));
        System.Console.WriteLine(text);
    }
}