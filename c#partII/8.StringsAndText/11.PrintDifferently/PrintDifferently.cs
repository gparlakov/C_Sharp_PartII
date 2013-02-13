//Write a program that reads a number and 
//prints it as a decimal number, hexadecimal number, 
//percentage and in scientific notation. Format the output
//aligned right in 15 symbols.

using System;

namespace _11.PrintDifferently
{
    class PrintDifferently
    {
        static void Main()
        {
            int number;
            try
            {
                number = int.Parse(Console.ReadLine());
                Console.WriteLine("{0,15:d}\n{0,15:x}\n{1,15:p}\n{0,15:e}", number,(double)number/100);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
