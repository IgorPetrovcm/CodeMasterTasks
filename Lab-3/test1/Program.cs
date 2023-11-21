using System;
using System.IO;
using System.Text;
namespace Program 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            string pathReadFile = @"C:\Users\Honor\Desktop\study C#\заметки\igor_petrov\Lab-3\ColorReplacement\Data\colors.txt";
            using (var colorsRead = new StreamReader(pathReadFile, Encoding.UTF8)) 
            {
                string line;
                while ((line = colorsRead.ReadLine()) != null) 
                {
                    int index2 = line.IndexOf(' ');
                    string name = line.Substring(0, index2);
                    System.Console.WriteLine(name);
                    int index = line.IndexOf('#');
                    string valColor = line.Substring(index+1);

                    int valRed = Convert.ToInt32(valColor[0].ToString() + valColor[1].ToString(), 16);
                    int valGreen = Convert.ToInt32(valColor[2].ToString() + valColor[3].ToString(),16);
                    int valBlue = Convert.ToInt32(valColor[4].ToString() + valColor[5].ToString(),16);
                    
                    System.Console.WriteLine(valRed + " " + valGreen + " " + valBlue);
                }
            }
        }
    }
}