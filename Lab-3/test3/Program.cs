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
            string path2 = @"C:\Users\Honor\Desktop\study C#\заметки\Test\test3\repl.txt";

            using (var writer = new StreamWriter(path2))
            using (var reader = new StreamReader(path)) 
            {
                string line;                 
                while ((line = reader.ReadLine()) != null) 
                {
                    Regex regex = new Regex(@"rgb\(\d{1,3}\, \d{1,3}\, \d{1,3}\)");
                    MatchCollection matches = regex.Matches(line);
                    foreach (Match match in matches) {
                        string res = match.Value.Replace("rgb(","").Replace(")","");
                        System.Console.WriteLine(res);
                        string[] arr = res.Split(", ");
                        line = line.Replace($"{match}",arr[0] + arr[1] + arr[2]);
                    }
                    writer.WriteLine(line);

                }
            }
        }
    }
}