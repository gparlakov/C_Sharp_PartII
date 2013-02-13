//Write a program to convert hexadecimal numbers to their decimal representation.

using System;
using System.Linq;
using System.Text;
using System.Numerics;


namespace HexadecimalToDec
{
    public class HexadecimalToDecimal
    {
        public static int charToDecimal(char symbol)
        {
            //this is in case the symbol is lowercase
            symbol = (symbol.ToString()).ToUpper()[0];

            int result = 0;
            if ((symbol - '0') >= 0 && (symbol - '0') <= 9)
            {
                result = symbol - '0';
            }
            else
            {
                result = symbol - 'A' + 10;
            }

            return result;
        }

        public static string decimalToString(int num)
        {
            string temp;
            if (num  > 9)
            {
                return ((char)(num - 10 + 'A')).ToString();
            }
            temp = num.ToString();
            return temp;
        }

        public static string AddNumbers(string first, string second, int numeralSystem)
        {
            int shorter = first.Length;
            int longer = second.Length;
            char longest = 's';
            StringBuilder sum = new StringBuilder();
            int tempResult = 0, rest = 0;


            if (shorter > longer)
            {
                longest = 'f';
                shorter = second.Length;
                longer = first.Length;
            }

            //reverse both strings to work from back on - for ease
            first = DecimalToBinary.DecimalToBinary.Reverse(first);
            second = DecimalToBinary.DecimalToBinary.Reverse(second);

            for (int i = 0; i < shorter; i++)
            {
                tempResult = charToDecimal(first[i]) + charToDecimal(second[i]) + rest;
                //if result is smaller than the numeral System
                //I just add it to the new string
                if (tempResult < numeralSystem)
                {
                    sum.Append(decimalToString(tempResult));
                    rest = 0;
                }
                else
                {
                    sum.Append(decimalToString(tempResult - numeralSystem));
                    rest = 1;
                }

            }

            //this below moves the rest of the longer number to tne sum
            for (int i = shorter; i < longer; i++)
            {
                if (longest == 'f')
                {
                    tempResult = charToDecimal(first[i]) + rest;
                    if (tempResult < numeralSystem)
                    {
                        sum.Append(decimalToString(tempResult));
                        rest = 0;
                    }
                    else
                    {
                        sum.Append(decimalToString(tempResult - numeralSystem));
                        rest = 1;
                    }

                }
                else
                {
                    tempResult = charToDecimal(second[i]) + rest;
                    if (tempResult < numeralSystem)
                    {
                        sum.Append(decimalToString(tempResult));
                        rest = 0;
                    }
                    else
                    {
                        sum.Append(decimalToString(tempResult - numeralSystem));
                        rest = 1;
                    }

                }
            }
            return DecimalToBinary.DecimalToBinary.Reverse(sum.ToString());
        }

        public static string AnyNumberToDecimal(string number, byte fromNumeral)
        {
            byte toNumeralSystem = 10;
            string turnedNumber = "0";
            BigInteger next = 0;

            for (int i = 0; i < number.Length; i++)
            {
                next = (BigInteger)(charToDecimal(number[i]) * Math.Pow(fromNumeral, number.Length - i - 1));
                turnedNumber = AddNumbers(turnedNumber, next.ToString(), toNumeralSystem);
            }
            return turnedNumber.ToString();
        }

        static void Main()
        {
            string binary = "01010111";
            string hex = "1234ABCDFF";
            string oct = "776655145307";
            //string check ="ABCD"//hexadecimalToAny(hexadec, 10);
            char a = 'f';
            int check1 = charToDecimal(a);
            Console.Write("Hexadecimal: {0} \nDecimal: ",hex);
            hex = AnyNumberToDecimal(hex, 16);
            Console.Write(hex);

            Console.Write("\nBinary: {0} \nDecimal: ", binary);
            binary = AnyNumberToDecimal(binary, 2);
            Console.Write(binary);

            Console.Write("\nOctodecimal(?): {0} \nDecimal: ", oct);
            oct = AnyNumberToDecimal(oct, 8);
            Console.Write(oct);
            Console.WriteLine();
        } 
    }
}
