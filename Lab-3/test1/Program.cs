using System;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
namespace Program 
{
    class Program 
    {
        static SortedList<string,string> colorsSorted = new SortedList<string,string>();
        static List<Color> colors = new List<Color>();
        static void AddColorInSortedList(Color color) 
        {
            foreach (string colorCheck in colorsSorted.Keys) 
            {
                if (color.ReturnAllValue16() == colorCheck) return;
            }
            colorsSorted.Add(color.ReturnAllValue16(),color.name);            
        }
        static string CheckedColorsValues(string val) 
        {
         foreach (Color color in colors) 
            {
                if ((color.redValue == Convert.ToInt32(val[0].ToString() + val[1].ToString(), 16) ) && 
                (color.greenValue == Convert.ToInt32(val[2].ToString() + val[3].ToString(),16) ) && 
                (color.blueValue == Convert.ToInt32(val[4].ToString() + val[5].ToString(),16) ) ) {   
                    AddColorInSortedList(color);                 
                    return color.name;
                }                
            }
            return val;   
        }
        static string FortmatToShortHex(string val) 
        {
            string valEdit = val.Substring(1);
            for (int i = 0; i < valEdit.Length;i++) 
            {
                valEdit = valEdit.Insert(i,valEdit[i].ToString());
                i++;
            }
            string valResult = CheckedColorsValues(valEdit);
            if (valResult == valEdit) return val;
            return valResult;
        }
        static string FormatToFullHex(string val) 
        {
            string valEdit = val.Substring(1).ToUpper();
            string valResult = CheckedColorsValues(valEdit);
            if (valResult == valEdit) return val;
            return valResult;
        }
        static string FormatToRgb(string val) 
        {
            string valEdit = val.Replace("rgb(","").Replace(")","");
            string[] values = valEdit.Split(", ");
            foreach (Color color in colors) 
            {
                if ( (color.redValue == int.Parse(values[0])) && 
                (color.greenValue == int.Parse(values[1])) && 
                (color.blueValue == int.Parse(values[2])) ) {
                    AddColorInSortedList(color);
                    return color.name;
                }
            }
            return val;
        }
        static void Main() 
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
            string pathUsedColorsFile = @"C:\Users\Honor\Desktop\study C#\заметки\igor_petrov\Lab-3\ColorReplacement\Data\used_colors.txt";

            if (File.Exists(pathTargetFile)) File.Delete(pathTargetFile);
            if (File.Exists(pathUsedColorsFile)) File.Delete(pathUsedColorsFile);

            using (var writer = new StreamWriter(pathTargetFile))
            using (var reader = new StreamReader(pathSourceFile)) 
            {
                string regexToRgb = @"rgb\(\d{1,3}\, \d{1,3}\, \d{1,3}\)";
                string regexToFullHex = @"\#\w{6}";
                string regexToShortHex = @"\#\w{3}";

                string line;
                while ((line = reader.ReadLine()) != null) 
                {
                    string matchNewName;
                    foreach (Match match in Regex.Matches(line,regexToRgb)) {
                        matchNewName = FormatToRgb(match.Value);
                        line = line.Replace(match.Value, matchNewName.ToString());
                    }
                    foreach (Match match in Regex.Matches(line, regexToFullHex)) {
                        matchNewName = FormatToFullHex(match.Value);
                        line = line.Replace(match.Value, matchNewName.ToString());
                    }
                    foreach (Match match in Regex.Matches(line, regexToShortHex)) {
                        matchNewName = FortmatToShortHex(match.Value);
                        line = line.Replace(match.Value, matchNewName.ToString());
                    }
                    writer.WriteLine(line);
                }
            }
            using (var writer = new StreamWriter(pathUsedColorsFile)) 
            {
                foreach (var color in colorsSorted) 
                {
                    writer.WriteLine(color.Key + " " + color.Value);
                }
            }

        }
    }
}