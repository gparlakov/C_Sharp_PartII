//Write a program to convert binary numbers to their decimal representation.

using System;


namespace BinaryToDecimal
{
    class BinaryToDecimal
    {
        static void Main()
        {
            string binary = "0010010101001001101010101";
            long numberDecimal=0;
            for (int i = 0; i <binary.Length; i++)
            {
                if (binary[i]=='1')
                {
                    numberDecimal += (long)Math.Pow(2,binary.Length-i-1);
                }
            }

            Console.WriteLine(numberDecimal);
            
        }
    }
}
