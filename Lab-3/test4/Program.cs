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
                    string regex3 = @"\#\w{3}";
                    /*foreach (Match match in Regex.Matches(line,regex1)) {
                        System.Console.WriteLine(match.Value);
                    }*/
                    /*foreach (Match match in Regex.Matches(line,regex2)) {
                        System.Console.WriteLine(Convert.ToInt32(match.Value.Substring(1).ToUpper(), 16));
                    }*/
                    foreach (Match match in Regex.Matches(line,regex3)) {
                        string handlerMatch = match.Value.Substring(1);
                        for (int i = 0; i < handlerMatch.Length; i++) 
                        {
                            handlerMatch = handlerMatch.Insert(i,handlerMatch[i].ToString());
                            i++;
                        }
                        System.Console.WriteLine(handlerMatch);
                    }
                }
                
            }
        }
    }
}