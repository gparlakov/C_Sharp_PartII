//Write a program to convert decimal numbers to their hexadecimal representation.

using System;
using System.Text;


namespace DecimalHexadecimal
{
    public class DecimalToHexadecimal
    {
        //So this method will add A,B,C.........W,X,Y,Z(if numeral system is Big Enough)
        public static string DecimalToOther(long numDecimal, int numeralSystem)
        {
            if (numDecimal==0)
            {
                return "0";
            }
            StringBuilder turnedNumber = new StringBuilder();
            while (numDecimal > 0)
            {
                long leftover = numDecimal % numeralSystem;
                if (leftover <= 9)
                {
                    turnedNumber.Append(leftover);
                }
                else
                {
                    turnedNumber.Append((char)(leftover - 10 + 'A'));
                }
                numDecimal /= numeralSystem;
            }
            return DecimalToBinary.DecimalToBinary.Reverse(turnedNumber.ToString());
        }

        static void Main()
        {
            long number = 1598756432154;
            Console.WriteLine(number);
            Console.WriteLine("Hexadecimal:");
            Console.WriteLine(DecimalToOther(number, 16));
            Console.WriteLine("Oct:");
            Console.WriteLine(DecimalToOther(number, 8));
            Console.WriteLine("32-numeral:");
            Console.WriteLine(DecimalToOther(number, 32));
            Console.WriteLine("36-numeral:");
            Console.WriteLine(DecimalToOther(number, 36));
            Console.WriteLine("7-nacci: ;)");
            Console.WriteLine(DecimalToOther(number, 7));
            Console.WriteLine("Binary: ");
            Console.WriteLine(DecimalToOther(number, 2));
        }
    }
}