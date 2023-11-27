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

            string file1Text = File.ReadAllText(@"C:\Users\Honor\Desktop\study C#\заметки\igor_petrov\Lab-3" +
            @"\WordCount\Data\Беда_одна_не_ходит.txt");
            /*byte[] bytes = File.ReadAllBytes(@"C:\Users\Honor\Desktop\study C#\заметки\igor_petrov\Lab-3" +
            @"\WordCount\Data\Начало.txt");*/
            file1Text += File.ReadAllText(@"C:\Users\Honor\Desktop\study C#\заметки\igor_petrov\Lab-3\" + 
            @"WordCount\Data\Хэппи_Энд.txt");

            file1Text = Regex.Replace(file1Text, @"[\r\n\t]", "");
            file1Text = file1Text.Replace(".","").Replace("-","").Replace("?","").Replace(",","").Replace("!","").Replace(@"""","").ToLower();

            System.Console.WriteLine(file1Text.Length);
            
            string[] words = file1Text.Split(' ');
            HashSet<string> hashes = new HashSet<string>();
            foreach (string word in words) {
                hashes.Add(word);
            }
            hashes.Remove("");
        }

    }
}
