 namespace Program
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = new string[3];
            int a = 5;
            for (int i = 0; i < 3; i++) {
            numbers[i] = Convert.ToString(a,2);
            }
            System.Console.WriteLine(string.Join(", ", numbers));

            int sum = 0;
            foreach (string num in numbers) {
                sum += int.Parse(num);
            }

            System.Console.WriteLine(Convert.ToString(sum,16));

            /*int[] arr = new int[5];
            for (int i = 0; i<arr.Length; i++) {
                arr[i] = i;
            }
            string arrJoin1 = string.Join(", ",arr);

            string[] strSplit = arrJoin1.Split(", ");
            for (int i = 0; i < strSplit.Length; i++) {}*/
        }
    }
}
