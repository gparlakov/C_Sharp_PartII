//Write a program to convert from any numeral system of 
//given base s to any other numeral system of base d (2 ≤ s, d ≤  16).

using System;
using System.Linq;
using HexadecimalToDec;
using DecimalHexadecimal;

namespace ConvertFromAnyToAny
{
    class ConvertFromAnyToAny
    {
        static string Convert(string num, byte FromNumeral, byte ToNumeralSystem=10)
        {
            num = HexadecimalToDecimal.AnyNumberToDecimal(num, FromNumeral);
            return DecimalToHexadecimal.DecimalToOther(long.Parse(num), ToNumeralSystem).ToString();            
        }

        
        static void Main()
        {
            string number = "ABCD1234";
            Console.WriteLine(Convert(number,16,2));
            Console.WriteLine(Convert(number, 16, 4));
            Console.WriteLine(Convert(number, 16, 8));
            Console.WriteLine(Convert(number, 16));
            Console.WriteLine(Convert(number, 16, 16));
            Console.WriteLine(Convert(number, 16, 32));

            string number1 = "8987465321";//decimal
            Console.WriteLine(Convert(number1, 10, 2));
            Console.WriteLine(Convert(number1, 10, 16));
            Console.WriteLine(Convert(number1, 10, 8));

            Console.WriteLine(Convert("1", 10, 2));
            Console.WriteLine(Convert("1", 2, 8));
            Console.WriteLine(Convert("1", 16, 2));
            Console.WriteLine(Convert("0", 10, 16));
            Console.WriteLine(Convert("0", 8, 16));
            Console.WriteLine(Convert("0", 2, 10));
        }
    }
}
