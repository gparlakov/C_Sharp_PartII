//Write a program that reads from the console a string of maximum 20 characters. 
//If the length of the string is less than 20, the rest of the characters 
//should be filled with '*'. Print the result string into the console.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameReadMax20Chars
{
    class ReadMax20Chars
    {
        static void Main()
        {
            char[] word = new char[20];
            System.ConsoleKeyInfo temp= new ConsoleKeyInfo();
            
            for (int i = 0; i < 20; i++)
            {
                temp=Console.ReadKey();
                if (temp.Key!=ConsoleKey.Enter)
                {
                    word[i] = temp.KeyChar; 
                }
                else
                {
                    for (i = i; i < 20; i++)
                    {
                        word[i] = '*';                        
                    }
                    break;
                }
            }
            Console.WriteLine();
            for (int i = 0; i < word.Length; i++)
            {
                Console.Write(word[i]);
            }           
            
        }
    }
}
