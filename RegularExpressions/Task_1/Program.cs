 namespace Program
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            int money = 28;
            string result = string.Format("{0:C4}",money);
            System.Console.WriteLine(result);
            string result2 = string.Format("{0:D3}",money);
            System.Console.WriteLine(result2);

            if (result2[0] == '0') System.Console.WriteLine("false");
            else System.Console.WriteLine("true");

            long number = 79659045406;
            string result3 = string.Format("{0:+# (###) ###-##-##}",number);
            string result4 = string.Format("{0:+0 (000) 000-00-00}",number);
            System.Console.WriteLine(result3);
            System.Console.WriteLine(result4);
        }
    }
}
