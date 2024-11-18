using System;
using System.Drawing;
using System.Globalization;

namespace Calculator
{
    internal class Program
    {
        bool isSmall(string s1, string s2)
        {
            if (s1.Length < s2.Length) return true;
            else if (s1.Length > s2.Length) { return false; }

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] < s2[i]) return true;
            }
            return false;
        }
        string Sum(string s1, string s2)
        {
            int rem = 0;
            string result = "";
            string bigStr = "";
            string smallStr = "";
            if (isSmall(s1, s2))
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

        string Sub(string s1, string s2)
        {
            if (s1 == s2)
            {
                return "0";
            }

            string first = " ";
            string second = " ";
            bool isNegative = false;

            if (isSmall(s1, s2))
            {
                first = s2;
                second = s1;
                isNegative = true;
            }
            else
            {
                first = s1;
                second = s2;
            }

            string res = "";
            int borrow = 0;

            for (int i = first.Length - 1, j = second.Length - 1; j >= 0; i--, j--)
            {
                int tmp = ((int)first[i] - '0') - ((int)second[j] - '0') - borrow;

                if (tmp < 0)
                {
                    tmp += 10;
                    borrow = 1;
                }
                else
                {
                    borrow = 0;
                }

                res = tmp + res;
            }

            for (int i = first.Length - second.Length - 1; i >= 0; i--)
            {
                int tmp = (int)first[i] - '0' - borrow;
                if (tmp < 0)
                {
                    tmp += 10;
                    borrow = 1;
                }
                else
                {
                    borrow = 0;
                }
                res = tmp + res;
            }

            res = res.TrimStart('0');

            if (string.IsNullOrEmpty(res))
            {
                res = "0";
            }

            if (isNegative)
            {
                res = "-" + res;
            }

            return res;
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
            if (s2 == "0") throw new DivideByZeroException("Can't divide by zero");
            else if (s1 == s2) return "1";
            else if (s1.Length < s2.Length || (s1.Length == s2.Length && string.Compare(s1, s2) < 0)) return "0";


            string res = "";
            string curr = "";

            for (int i = 0; i < s1.Length; i++)
            {
                curr += s1[i];
                if (curr.Length == 0) continue;

                if (curr.Length < s2.Length || (curr.Length == s2.Length && string.Compare(curr, s2) < 0))
                {
                    res += "0";
                    continue;
                }

                int count = 0;
                while (curr.Length > s2.Length || (curr.Length == s2.Length && string.Compare(curr, s2) >= 0))
                {
                    curr = Sub(curr, s2);
                    count++;
                }
                res += count;
            }
            return string.IsNullOrEmpty(res) ? "0" : res.TrimStart('0');
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
            //Console.Write(Ob.Mul(input1, input2));
            Console.WriteLine(Ob.Div(input1, input2));
        }
    }
}