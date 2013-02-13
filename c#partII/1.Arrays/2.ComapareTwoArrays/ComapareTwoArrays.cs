//Write a program that reads two arrays from the console and compares them element by element.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.ComapareTwoArrays
{
    class ComapareTwoArrays
    {
        static void Main(string[] args)
        {
            int n;
            bool equal = true;
            do
            {
                Console.WriteLine("How long will the two arrays be?");
            } while (!int.TryParse(Console.ReadLine(), out n));
    
            int[] firstArray = new int[n];
            int[] secondArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                do
                {
                    Console.Write("First array[{0}]: ",i);
                } while (!int.TryParse(Console.ReadLine(), out firstArray[i]));
                
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                do
                {
                    Console.Write("Second array[{0}]: ", i);
                } while (!int.TryParse(Console.ReadLine(), out secondArray[i]));
            }
            for (int i = 0; i < n; i++)
            {
                if (firstArray[i]!=secondArray[i])
                {
                    equal = false;
                }
            }
            Console.WriteLine("Equal arrays? ->{0}",equal);
        }
    }
}
