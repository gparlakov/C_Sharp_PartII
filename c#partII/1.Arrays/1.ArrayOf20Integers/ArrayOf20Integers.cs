//Write a program that allocates array of 20 integers and initializes 
//each element by its index multiplied by 5. Print the obtained array on the console.



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.ArrayOf20Integers
{
    class ArrayOf20Integers
    {
        static void Main(string[] args)
        {
            int[] twentyIntegers = new int[20];
            for (int i = 0; i < twentyIntegers.Length; i++)
            {
                twentyIntegers[i] = 5 * i;
                Console.Write(twentyIntegers[i]+", ");
            }

        }
    }
}
