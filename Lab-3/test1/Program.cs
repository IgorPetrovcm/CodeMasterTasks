using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
namespace Program 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            string pathReadFile = @"C:\Users\Honor\Desktop\study C#\заметки\igor_petrov\Lab-3\ColorReplacement\Data\source.txt";
            using (var colorsRead = new StreamReader(pathReadFile, Encoding.UTF8)) 
            {
                string line;                
                while ((line = colorsRead.ReadLine()) != null) 
                {
                    Regex regex = new Regex(@"^rgb\(\d{1,3}\, \d{1,3}\, \d{1,3}\)");
                    MatchCollection matchCollection = regex.Matches(line);
                    foreach (Match match in matchCollection) {
                        System.Console.WriteLine(match.Value);
                    }
                }
            }
        }
    }
}