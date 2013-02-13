using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinToHex
{
    class BinaryToHex
    {
        static string FourBitsToHex(string four)
        {
            int result = 0;
            int powerOfTwo = 8;
            for (int i = 0; i < 4; i++)
            {
                result += (four[i]-'0') * powerOfTwo;
                powerOfTwo /= 2;
            }
            if (result <10)
            {
                return result.ToString();
            }
            return ((char)(result - 10 + 'A')).ToString();

        }

        private static string FillBinaryString(string bin)
        {
            if (bin.Length % 4 != 0||bin.Length<4)
            {
                string fillUp = new string('0', 4 - (bin.Length % 4));
                bin = fillUp + bin;
            }
            return bin;
        }

        private static string BinToHex(string binary)
        {
            binary = FillBinaryString(binary);
            StringBuilder fourth = new StringBuilder();
            StringBuilder hexadecimal = new StringBuilder();
            for (int i = 0; i < binary.Length; i++)
            {
                fourth.Append(binary[i]);
                if ((i + 1) % 4 == 0)
                {
                    hexadecimal.Append(FourBitsToHex(fourth.ToString()));
                    fourth.Clear();
                }

            }
            return hexadecimal.ToString();
        }
        
        static void Main()
        {
            string binary = "1001101010111";
            binary = FillBinaryString(binary);
            string hex = BinToHex(binary);

            Console.WriteLine("100110110101 to hex : {0}", BinToHex("100110110101"));
            Console.WriteLine("11111000 to hex : {0}", BinToHex("11111000"));
            Console.WriteLine("1011011011010111011011 to hex : {0}", BinToHex("11011011010111011011"));
            Console.WriteLine("101000101110101110101110101 to hex : {0}", BinToHex("101000101110101110101110101"));
            Console.WriteLine("011 to hex : {0}", BinToHex("011"));
            Console.WriteLine("0 to hex : {0}", BinToHex("0"));
        }

        

        
    }
}
