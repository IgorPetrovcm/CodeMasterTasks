namespace WordCount
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            string text = File.ReadAllText(@"C:\Users\Honor\Desktop\study C#\заметки\igor_petrov\Lab-3" +
            @"\WordCount\Data\Беда_одна_не_ходит.txt");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            text += File.ReadAllText(@"C:\Users\Honor\Desktop\study C#\заметки\igor_petrov\Lab-3" +
            @"\WordCount\Data\Начало.txt",Encoding.GetEncoding(1251));
            text += File.ReadAllText(@"C:\Users\Honor\Desktop\study C#\заметки\igor_petrov\Lab-3\" + 
            @"WordCount\Data\Хэппи_Энд.txt");

            text = Regex.Replace(text, @"[\r\n\t]", "");
            text = text.Replace(".","").Replace("-","").Replace("?","").Replace(",","").Replace("!","").Replace(@"""","").ToLower();
            
            string[] words = text.Split(' ');
            HashSet<string> hashes = new HashSet<string>();
            foreach (string word in words) {
                hashes.Add(word);
            }
            hashes.Remove("");
            System.Console.WriteLine(hashes.Count);
        }

    }
}
