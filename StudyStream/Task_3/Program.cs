 namespace Program
{
    using System;
    using System.IO;
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo[] dirs = new DirectoryInfo("/home/admin/").GetDirectories();
            using (StreamWriter writer = new StreamWriter("test.txt")) 
            {
                foreach (DirectoryInfo dir in dirs) {
                    writer.WriteLine(dir.Name);
                }
            }
            using (StreamReader reader = new StreamReader("test.txt")) 
            {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    System.Console.WriteLine(line);
                }
            }
        }
    }
}
