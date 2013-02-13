//Write a program to convert hexadecimal numbers to binary numbers (directly).

using System;
using HexadecimalToDec;
using System.Text;

namespace HexToBin
{
    class HexTOBin
    {
        static string CharToBinary(char ch)
        {
            int number = HexadecimalToDecimal.charToDecimal(ch);

            StringBuilder result = new StringBuilder();
            byte[] res = { 0, 0, 0, 0 };
            byte i = 3;
            while (number> 0)
            {
                res[i]=(byte)(number % 2);
                i--;
                number /= 2;
            }
            for (i = 0; i < 4; i++)
            {
                result.Append(res[i]);   
            }
            return result.ToString(); 
        }
        
        static void Main()
        {
            string hexadecimal = "AABBCCDDEEFF";
            StringBuilder binary = new StringBuilder();
            for (int i = 0; i < hexadecimal.Length; i++)
            {
                binary.Append(CharToBinary(hexadecimal[i]));
            } 
        }
    }
}
