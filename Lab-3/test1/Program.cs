using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
namespace Program 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            List<Color> colors = new List<Color>();
            string pathColorsFile = @"C:\Users\Honor\Desktop\study C#\заметки\igor_petrov\Lab-3\ColorReplacement\Data\colors.txt";
            using (var reader = new StreamReader(pathColorsFile)) 
            {
                string line;
                while ((line = reader.ReadLine()) != null) 
                {
                    Color color = new Color();
                    color.SetValues(line);
                    colors.Add(color);
                    System.Console.WriteLine(color.ToString());
                }
            } 
        }
    }
}