//Write a program to convert decimal numbers to their binary representation.

using System;
using System.Text;


namespace DecimalToBinary
{
    public class DecimalToBinary
    {
        public static string Reverse(string num)
        {
            StringBuilder reversed = new StringBuilder();
            
            for (int i = num.Length-1; i>=0; i--)
            {
                reversed.Append(num[i]);
            }
            return reversed.ToString();
        }

        public static string DecimalToBin(long number)
        {
            StringBuilder binary = new StringBuilder();

            while (number > 0)
            {
                binary.Append(number % 2);
                number /= 2;
            }
            
            return Reverse(binary.ToString());
        }
        
        static void Main()
        {
            Random genarator = new Random();
            long number = genarator.Next();
            Console.WriteLine(number);
            Console.WriteLine(DecimalToBin(number));

        }

        
    }
}
