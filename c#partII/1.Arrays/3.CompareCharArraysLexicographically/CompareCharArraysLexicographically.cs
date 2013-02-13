//Write a program that compares two char arrays lexicographically (letter by letter).

using System;

using System.Linq;

namespace CompareCharArraysLexicographically
{
    class CompareCharArraysLexicographically
    {
        static void Main(string[] args)
        {
            int n;
            bool equal = true;
            do
            {
                Console.WriteLine("How long will the two arrays be?");
            } while (!int.TryParse(Console.ReadLine(), out n));

            char[] firstArray =  new char[n];
            char[] secondArray = new char[n];
            for (int i = 0; i < n; i++)
            {
                do
                {
                    Console.Write("First array[{0}]: ", i);
                } while (!char.TryParse(Console.ReadLine(), out firstArray[i]));

            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                do
                {
                    Console.Write("Second array[{0}]: ", i);
                } while (!char.TryParse(Console.ReadLine(), out secondArray[i]));
            }
            for (int i = 0; i < n; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    equal = false;
                }
            }
            Console.WriteLine("Equal arrays? ->{0}", equal);
        }
    }
}
 