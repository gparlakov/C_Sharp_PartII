//Write a program that encodes and decodes a string using given encryption key (cipher). 
//The key consists of a sequence of characters. The encoding/decoding is done by performing
//XOR (exclusive or) operation over the first letter of the string with the first of the key, 
//the second – with the second, 
//etc. When the last key character is reached, the next is the first.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameCodeUsingXOR
{
    class CodeUsingXOR
    {
        static void Main(string[] args)
        {
            string cypherKey = "MyName";
            string text = @"Write a program that encodes and decodes a string using given encryption key (cipher).The key consists of a sequence of characters. The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key, the second – with the second, etc. When the last key character is reached, the next is the first";
            text = CipherDecipher(text, cypherKey);
            Console.WriteLine(text);
            text = CipherDecipher(text, cypherKey);
            Console.WriteLine(text);
        }

        private static string CipherDecipher(string text, string cypherKey)
        {
            int startIndex = 0;
            string temp;
            StringBuilder cyphered = new StringBuilder();
            do
            {
                if (startIndex + cypherKey.Length > text.Length)
                {
                    temp = text.Substring(startIndex, text.Length - startIndex);
                }
                else
                {
                    temp = text.Substring(startIndex, cypherKey.Length);
                }
                for (int i = 0; i < temp.Length; i++)
                {
                    cyphered.Append((char)(temp[i] ^ cypherKey[i]));
                }
                startIndex += cypherKey.Length;
            } while (startIndex < text.Length);

            return cyphered.ToString();
        }
    }
}
