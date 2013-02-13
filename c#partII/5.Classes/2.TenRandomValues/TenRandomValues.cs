//Write a program that generates and prints to the 
//console 10 random values in the range [100, 200].

using System;

namespace NameTenRandomValues
{
    class TenRandomValues
    {
        static void Main()
        {
            Random ranGen = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(ranGen.Next(100,201));
            }
        }
    }
}
