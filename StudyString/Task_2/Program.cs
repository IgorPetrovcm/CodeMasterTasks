 namespace Program
{
    //Программа создает дату из введенного числа длиною 8 
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            string dateInput = Console.ReadLine();
            string dateFormat = int.Parse(dateInput).ToString("0000-00-00");

            string[] dateArr = dateFormat.Split('-');
            DateTime date = new DateTime(int.Parse(dateArr[0]), int.Parse(dateArr[1]), int.Parse(dateArr[2]));
            System.Console.WriteLine(date);
        }
    }
}
