using System;
using System.IO;
using System.Text;
namespace Program 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            try 
            {
                using (StreamReader sr = new StreamReader("reader.txt")) 
                {
                    List<byte> bytes = new List<byte>();
                    while (sr.Read() != null ) 
                    {
                        
                        bytes.Add(Convert.ToByte(sr.Read()));
                    }
                    Encoding ascii = Encoding.ASCII;
                    byte[] bytesToStr = new byte[bytes.Count];

                    int count = 0;
                    foreach (byte c in bytes) {
                        bytesToStr[count] = c;
                        count++;
                    }
                    string text = ascii.GetString(bytesToStr); 
                    Console.WriteLine(text);
                }
            }
            catch 
            {
                Console.WriteLine("File is not found or file no correct!");
            }
        }
    } 
}