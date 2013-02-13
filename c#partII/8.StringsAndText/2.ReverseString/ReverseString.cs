//Write a program that reads a string, reverses it and prints the result at the console.
//Example: "sample"  "elpmas".

using System;


namespace NameReverseString
{
    class ReverseString
    {
        static void Main(string[] args)
        {
            string newString = Console.ReadLine();
            for (int i = newString.Length-1; i >= 0; i--)
            {
                Console.Write(newString[i]);
            }
            Console.WriteLine();
        }
    }
}
