using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repetitiveNumber
{
    internal class Program
    {
    
        static int average(int num)
        {
            int size = 0;
            int newNum = num;
            while(num!=0)
            {
                num/= 10;
                ++size;
            }
            int sum = 0;
            HashSet<int> sorted = new HashSet<int>();
            for(int i = 0;i<size;i++)
            {
                sorted.Add(newNum%10);
                newNum = newNum/10;
            }
            foreach(int i in sorted)
            {
                sum += i;
            }
            sum=sum/sorted.Count;
            return sum;
        }    
        static void Main(string[] args)
        {
            Console.Write("Enter a number - ");
            int num=int.Parse(Console.ReadLine());
            Console.WriteLine(average(num));
        }
    }
}
