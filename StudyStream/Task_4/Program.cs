 namespace Program
{
    using System;
    using System.IO;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "testFile.txt";

            if (File.Exists(fileName)) {
                File.Delete(fileName);
            }

            Encoding unicode = Encoding.Unicode;            
            using (FileStream fs = File.Create(fileName, 1024)) 
            {
                byte[] bytes = unicode.GetBytes("Hello World\nHello Guys");
                fs.Write(bytes,0,bytes.Length);
            }

            using (StreamReader reader = File.OpenText(fileName)) 
            {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    System.Console.WriteLine(line);
                }
            }
        }
    }
}
