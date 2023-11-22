using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
namespace Program 
{
    class Program 
    {
        static List<Color> colors = new List<Color>();
        static string Format3(string val) 
        {
            string valEdit = val.Substring(1);
            for (int i = 0; i < valEdit.Length;i++) 
            {
                valEdit = valEdit.Insert(i,valEdit[i].ToString());
                i++;
            }
            foreach (Color color in colors) 
            {
                if ((color.RedValue == Convert.ToInt32(valEdit[0].ToString() + valEdit[1].ToString(), 16) ) && 
                (color.GreenValue == Convert.ToInt32(valEdit[2].ToString() + valEdit[3].ToString(),16) ) && 
                (color.BlueValue == Convert.ToInt32(valEdit[4].ToString() + valEdit[5].ToString(),16) ) ) {
                    return color.Name;
                }                
            }
            return val;

        }
        static string Format2(string val) 
        {
            string valEdit = val.Substring(1).ToUpper();
            foreach (Color color in colors) 
            {
                if ((color.RedValue == Convert.ToInt32(valEdit[0].ToString() + valEdit[1].ToString(), 16) ) && 
                (color.GreenValue == Convert.ToInt32(valEdit[2].ToString() + valEdit[3].ToString(),16) ) && 
                (color.BlueValue == Convert.ToInt32(valEdit[4].ToString() + valEdit[5].ToString(),16) ) ) {
                    return color.Name;
                }                
            }
            return val;
        }
        static string Format1(string val) 
        {
            string valEdit = val.Replace("rgb(","").Replace(")","");
            string[] values = valEdit.Split(", ");
            foreach (Color color in colors) 
            {
                if ( (color.RedValue == int.Parse(values[0])) && 
                (color.GreenValue == int.Parse(values[1])) && 
                (color.BlueValue == int.Parse(values[2])) ) {
                    return color.Name;
                }
            }
            return val;
        }
        static void Main(string[] args) 
        {
            string pathColorsFile = @"C:\Users\Honor\Desktop\study C#\заметки\igor_petrov\Lab-3\ColorReplacement\Data\colors.txt";
            using (var reader = new StreamReader(pathColorsFile)) 
            {
                string line;
                while ((line = reader.ReadLine()) != null) 
                {
                    Color color = new Color();
                    color.SetValues(line);
                    colors.Add(color);
                }
            } 

            string pathSourceFile = @"C:\Users\Honor\Desktop\study C#\заметки\igor_petrov\Lab-3\ColorReplacement\Data\source.txt";
            string pathTargetFile = @"C:\Users\Honor\Desktop\study C#\заметки\igor_petrov\Lab-3\ColorReplacement\Data\target.txt";
            if (File.Exists(pathTargetFile)) {
                File.Delete(pathTargetFile);                
            }

            using (var writer = new StreamWriter(pathTargetFile))
            using (var reader = new StreamReader(pathSourceFile)) 
            {
                string regex1 = @"rgb\(\d{1,3}\, \d{1,3}\, \d{1,3}\)";
                string regex2 = @"\#\w{6}";
                string regex3 = @"\#\w{3}";

                string line;
                while ((line = reader.ReadLine()) != null) 
                {
                    string matchNewName;
                    foreach (Match match in Regex.Matches(line,regex1)) {
                        matchNewName = Format1(match.Value);
                        line = line.Replace(match.Value, matchNewName.ToString());
                    }
                    foreach (Match match in Regex.Matches(line, regex2)) {
                        matchNewName = Format2(match.Value);
                        line = line.Replace(match.Value, matchNewName.ToString());
                    }
                    foreach (Match match in Regex.Matches(line, regex3)) {
                        matchNewName = Format3(match.Value);
                        line = line.Replace(match.Value, matchNewName.ToString());
                    }
                    writer.WriteLine(line);
                }
            }
        }
    }
}