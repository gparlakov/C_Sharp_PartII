//Write a method GetMax() with two parameters that returns the bigger of two integers. Write a program that 
//reads 3 integers from the console and prints the biggest of them using the method GetMax().

using System;

namespace _2.GetMaximalOfTwoInts
{
    class GetMaximalOfTwoInts
    {
        static int GetMax(int first, int second)
        {
            if (first>second)
            {
                return first;
            }
            return second;
        }
        
        static void Main(string[] args)
        {
            int[] numbers = new int[3];
            for (int i = 0; i < 3; i++)
            {
                do
                {
                    Console.Write("Number {0} :",i);
                } while (!int.TryParse(Console.ReadLine(),out numbers[i]));
            }
            
            Console.WriteLine(GetMax(numbers[0],GetMax(numbers[1],numbers[2])));
        }
    }
}
