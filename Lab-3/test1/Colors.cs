using System;
namespace Program 
{
    public class Color
    {
        int redValue;
        int greenValue;
        int blueValue;
        string name;

        public int RedValue {get {return redValue;} private set {redValue = value;}}
        public int GreenValue {get {return greenValue;} private set {greenValue = value;}}
        public int BlueValue {get {return blueValue;} private set {blueValue = value;}}
        public string Name {get {return name;} private set {name = value;}}

        public Color(int redVal=0, int greenVal=0, int blueVal=0, string name=null) 
        {
            RedValue = redVal;
            GreenValue = greenVal;
            BlueValue = blueVal;
            Name = name;
        }

        public void SetValues(string line) 
        {
            int indexEndName = line.IndexOf(' ');
            Name = line.Substring(0, indexEndName);

            int indexValues = line.IndexOf('#');
            string lineValues = line.Substring(indexValues+1);

            RedValue = Convert.ToInt32(lineValues[0].ToString() + lineValues[1].ToString(), 16);
            GreenValue = Convert.ToInt32(lineValues[2].ToString() + lineValues[3].ToString(), 16);
            BlueValue = Convert.ToInt32(lineValues[4].ToString() + lineValues[5].ToString(), 16);
        }

        public override string ToString()
        {
            return $"{Name}\t{RedValue}-{GreenValue}-{BlueValue}";
        }
        public int ReturnAllValue() 
        {
            return Convert.ToInt32($"{RedValue}{GreenValue}{BlueValue}");
        }
    }
}