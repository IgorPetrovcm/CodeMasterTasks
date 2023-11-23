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

            string file1Text = File.ReadAllText(@"C:\Users\Honor\Desktop\study C#\заметки\igor_petrov\Lab-3\WordCount\Data\Беда_одна_не_ходит.txt");
            file1Text += File.ReadAllText(@"C:\Users\Honor\Desktop\study C#\заметки\igor_petrov\Lab-3\WordCount\Data\Начало.txt");
            file1Text += File.ReadAllText(@"C:\Users\Honor\Desktop\study C#\заметки\igor_petrov\Lab-3\WordCount\Data\Хэппи_Энд.txt");
            file1Text = Regex.Replace(file1Text, @"[\r\n\t]", "");
            file1Text = file1Text.Replace(".","").Replace("-","").Replace("?","").Replace(",","").Replace("!","").Replace(@"""","").ToLower();
            string regex = @"\ \w{1}\ ";
            foreach (Match match in Regex.Matches(file1Text,regex)) 
            {
                file1Text = file1Text.Replace(match.Value, " ");
            }
            System.Console.WriteLine(file1Text.Length);

            List<string> uniqueWords = new List<string>(100);
            string regex2 = @"\w{2,20}";
            foreach (Match match in Regex.Matches(file1Text,regex2)) 
            {
                uniqueWords.Add(match.Value);
                file1Text = file1Text.Replace(match.Value, "");
            }
            System.Console.WriteLine(uniqueWords.Count());
            
        }

        private static int CalculateWordCount(string text)
        {
            int wordCount = 0;
            foreach (char ch in text)
            {
                if (char.IsLetterOrDigit(ch))
                {
                    wordCount++;
                }
            }

            return wordCount;
        }
    }
}
