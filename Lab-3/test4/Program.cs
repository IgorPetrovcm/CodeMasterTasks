using System;
using System.IO;
using System.Text.RegularExpressions;
namespace Program 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            string sourceFile = @"C:\Users\Honor\Desktop\study C#\заметки\igor_petrov\Lab-3\ColorReplacement\Data\source.txt";
            using (var reader = new StreamReader(sourceFile)) 
            {
                string line;
                while ((line = reader.ReadLine()) != null) 
                {
                    string regex1 = @"rgb\(\d{1,3}\, \d{1,3}\, \d{1,3}\)";
                    string regex2 = @"\#\w{6}";
                    /*foreach (Match match in Regex.Matches(line,regex1)) {
                        System.Console.WriteLine(match.Value);
                    }*/
                    foreach (Match match in Regex.Matches(line,regex2)) {
                        System.Console.WriteLine(Convert.ToInt32(match.Value.Substring(1).ToUpper(), 16));
                    }
                }
                
            }
        }
    }
}