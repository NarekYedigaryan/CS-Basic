using System;
using System.Drawing;
using System.Globalization;

namespace Calculator
{
    internal class Program
    {
        string Sub(string s1, string s2)
        {
            if (s1 == s2)
            {
                return "0";
            }
            string res = "";
            string first = " ";
            string second = " ";
            if (s1.Length < s2.Length)
            {
                first = s2;
                second = s1;
            }
            else
            {
                first = s1;
                second = s2;
            }
            for (int i = first.Length - 1, j = second.Length - 1; j >= 0; i--, j--)
            {
                int tmp = ((int)first[i] - '0') - ((int)second[j] - '0');

                if (tmp < 0 && i != 0)
                {
                    tmp += 10;
                    char[] firstArray = first.ToCharArray();
                    firstArray[i - 1] = (char)(firstArray[i - 1] - 1);
                    first = new string(firstArray);
                }
                res = tmp + res;
            }
            for (int i = first.Length - second.Length - 1; i >= 0; i--)
            {
                int tmp = (int)first[i] - '0';
                res = tmp + res;
            }
            if (s1.Length < s2.Length) { res = "-" + res; }
            return res;
        }
        string Sum(string s1, string s2)
        {
            int rem = 0;
            string result = "";
            string bigStr = "";
            string smallStr = "";
            if (s1.Length < s2.Length)
            {
                bigStr = s2;
                smallStr = s1;
            }
            else
            {
                bigStr = s1;
                smallStr = s2;
            }
            for (int i = bigStr.Length - 1, j = smallStr.Length - 1; j >= 0; i--, j--)
            {
                int tmp = ((int)bigStr[i] - '0') + ((int)smallStr[j] - '0') + rem;
                if (tmp >= 10)
                {
                    rem = 1;
                    tmp %= 10;
                }
                else
                {
                    rem = 0;
                }
                result = (tmp.ToString()) + result;
            }
            for (int i = bigStr.Length - smallStr.Length - 1; i >= 0; i--)
            {
                int tmp = ((int)bigStr[i] - '0') + rem;
                if (tmp >= 10)
                {
                    rem = 1;
                    tmp %= 10;
                }
                else
                {
                    rem = 0;
                }
                result = tmp.ToString() + result;
            }

            if (rem != 0) { result = "1" + result; }

            return result;
        }

        string Mul(string s1, string s2)
        {
            if (s1 == "0" || s2 == "0")
            {
                return "0";
            }
            if (s1.Length < s2.Length)
            {
                (s1, s2) = (s2, s1);
            }
            string res = "0";
            for (int i = s2.Length - 1; i >= 0; i--)
            {
                int tmp = 0;
                string str = "";
                for (int j = s1.Length - 1; j >= 0; j--)
                {
                    tmp += ((s1[j] - '0') * (s2[i] - '0'));
                    str = (tmp % 10).ToString() + str;
                    tmp /= 10;
                    if (tmp != 0 && j == 0)
                    {
                        str = tmp.ToString() + str;
                    }
                }
                str = str.PadRight(str.Length + (s2.Length - 1 - i), '0');
                res = Sum(str, res);
            }
            return res;
        }
        string Div(string s1, string s2)
        {
            string res = "0";


            return res;
        }
        static void Main(string[] args)
        {
            Program Ob = new Program();
            Console.Write("Enter first number - ");
            string input1 = Console.ReadLine();

            Console.Write("Enter second number - ");
            string input2 = Console.ReadLine();

            Console.Write("The result is - ");
            //Console.Write(Ob.Sum(input1,input2));
            //Console.Write(Ob.Sub(input1,input2));
            Console.Write(Ob.Mul(input1, input2));
        }
    }
}