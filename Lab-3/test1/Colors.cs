using System;
using System.Security.Cryptography.X509Certificates;
namespace Program 
{
    public class Color
    {
        public int redValue {get;private set;}
        public int greenValue {get;private set;}
        public int blueValue {get;private set;}
        public string name {get;private set;}

        public Color(int redVal=0, int greenVal=0, int blueVal=0, string name=null) 
        {
            this.redValue = redVal;
            this.greenValue = greenVal;
            this.blueValue = blueVal;
            this.name = name;
        }

        public void SetValues(string line) 
        {
            int indexEndName = line.IndexOf(' ');
            name = line.Substring(0, indexEndName);

            int indexValues = line.IndexOf('#');
            string lineValues = line.Substring(indexValues+1);

            redValue = Convert.ToInt32(lineValues[0].ToString() + lineValues[1].ToString(), 16);
            greenValue = Convert.ToInt32(lineValues[2].ToString() + lineValues[3].ToString(), 16);
            blueValue = Convert.ToInt32(lineValues[4].ToString() + lineValues[5].ToString(), 16);
        }

        public override string ToString()
        {
            return $"{name}\t{redValue}-{greenValue}-{blueValue}";
        }
        public int ReturnAllValue() 
        {
            return Convert.ToInt32($"{redValue}{greenValue}{blueValue}");            
        }
        public string ReturnAllValue16() 
        {
            return redValue.ToString("X2") + greenValue.ToString("X2") + blueValue.ToString("X2");
        }
    }
}