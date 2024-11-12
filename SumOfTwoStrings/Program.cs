using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SumOfTwoStrings
{
    internal class Program
    {
        static string Sum(string num1, string num2) 
        {
            string sum = " ";
            String a = " ";
            String b = " ";
            int i1 = 0;
            int i2 = 0;
            if(num1.Length>num2.Length)
            {
                a=num1;
                b=num2;
                i1 = a.Length - 1;
                i2 = b.Length - 1;
            }
            else
            {
                a = num2;
                b = num1;
                i1 = a.Length - 1;
                i2 = b.Length - 1;
            }
            int carry = 0;
            int tmp = 0;
            for(int i = 0;i<a.Length;i++)
            {
                if(i1==0)
                {
                    sum += (((a[i1] + carry-'0'))%10).ToString();
                    if(carry==1)
                    {
                        sum += carry.ToString();
                    }
                }
                else if(i2<0)
                {
                    tmp = (int)(a[i1] + carry - '0');
                    if(tmp<10)
                    {
                        sum += (tmp).ToString();
                        carry = 0;
                    }
                    else
                    {
                        sum += (tmp%10).ToString();
                        carry = 1;
                    }
                    
                }
                else if( i1>=0)
                {
                    tmp = a[i1] - '0' + b[i2] - '0';
                    if(tmp < 10)
                    {
                        sum += (tmp+carry).ToString();
                        carry = 0;
                    }
                    else
                    {
                        
                        sum += ((tmp % 10)+carry).ToString();
                        carry = 1;
                    }
                   
                }
                
                --i1;
                --i2;
            }
            string reversedSum = new string(sum.ToCharArray().Reverse().ToArray());
            return reversedSum;

        }
        static void Main(string[] args)
        {
            Console.Write("Enter first string - ");
            string num1=Console.ReadLine();
            Console.Write("Enter second string - ");
            string num2 =Console.ReadLine();
            Console.WriteLine(Sum(num1, num2));
        }
    }
}
