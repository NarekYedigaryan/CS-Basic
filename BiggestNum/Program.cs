using System;

namespace BiggestNum
{
    internal class Program
    {
        static int biggest(int num)
        {
            int i = 0;
            int max = num % 10;
            while (num != 0)
            {
                if (max <= num % 10)
                {
                    max = num % 10;
                    i++;
                }
                num /= 10;
            }
            return i;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter a number - ");
            string input = Console.ReadLine();
            
            if (!string.IsNullOrEmpty(input))
            {
                double num = double.Parse(input);
                Console.WriteLine(biggest((int)num));
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
