using System;
using System.IO;
using System.Text.RegularExpressions;
namespace Program 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            string path = @"C:\Users\Honor\Desktop\study C#\заметки\igor_petrov\Lab-3\ColorReplacement\Data\source.txt";

            using (var reader = new StreamReader(path)) 
            {
                string line;                 
                while ((line = reader.ReadLine()) != null) 
                {
                    Regex regex = new Regex(@"^rgb\(\d{1,3}\, \d{1,3}\, \d{1,3}\)");
                    MatchCollection matches = regex.Matches(line);
                    foreach (Match match in matches) {
                        System.Console.WriteLine(match.Value);
                    }
                }
            }
        }
    }
}