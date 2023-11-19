 namespace Program
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0xFF;
            System.Console.WriteLine(a);

            System.Console.WriteLine(a.ToString("0x00"));

            int date = 20090822;
            Console.WriteLine(date.ToString("0000-00-00"));

            string dateSp = date.ToString("0000-00-00");
            
            string[] splitStr = dateSp.Split('-');
            foreach (string str in splitStr) {
                System.Console.WriteLine(str);
            }

            System.Console.WriteLine(new DateTime(int.Parse(splitStr[0]), int.Parse(splitStr[1]), int.Parse(splitStr[2])));
        }
    }
}
