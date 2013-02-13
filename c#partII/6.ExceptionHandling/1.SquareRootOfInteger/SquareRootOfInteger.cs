//Write a program that reads an integer number and calculates and 
//prints its square root. If the number is invalid or negative, print "Invalid number".
//In all cases finally print "Good bye". Use try-catch-finally.

using System;

namespace NameSquareRootOfInteger
{
    class SquareRootOfInteger
    {
        static void Main()
        {
            int number;
            try
            {
                Console.WriteLine("Number: ");
                number = int.Parse(Console.ReadLine());
                if (number<0)
                {
                    throw new FormatException("Invalid number");
                }
                Console.WriteLine(Math.Sqrt(number));
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good Bye");
            }
        }
    }
}
