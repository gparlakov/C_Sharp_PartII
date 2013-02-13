//Write a method ReadNumber(int start, int end) //that enters an integer number in given range [start…end]. //If an invalid number or non-number text is entered, the method should//throw an exception. Using this method write a program that enters 10 numbers://            a1, a2, … a10, such that 1 < a1 < … < a10 < 100

using System;
using System.Collections.Generic;
using System.Linq;


namespace NameReadNumerInSpecificRange
{
    class ReadNumerInSpecificRange
    {        
        static int ReadNumber(int start,int end)
        {
            int num ;
            try
            {
                num = int.Parse(Console.ReadLine());
                if (num < start || num > end)
                {                    
                    throw new FormatException();
                }                
            }
            catch(FormatException)
            {
                string error = String.Format("Invalid Number.Should be greater than {0} and lesser then {1}", start, end);
                throw new FormatException(error);
            }
            return num;

        }
        
        static void Main()
        {
            List<int> numbers = new List<int>(10);
            do
            {
                try
                {
                    Console.Write("Number [{0}]: ", numbers.Count+1);
                    if (numbers.Count==0)
                    {                        
                        numbers.Add(ReadNumber(1, 100)); 
                    }
                    else
                    {
                        numbers.Add(ReadNumber(numbers[numbers.Count-1],100));
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (numbers.Count<10);

            foreach (var num in numbers)
            {
                Console.Write(num + " ");
            }
        }
    }
}
