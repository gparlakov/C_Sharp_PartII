//You are given a sequence of positive integer values written into a string,//separated by spaces. Write a function that reads these values from given string //and calculates their sum. Example://        string = "43 68 9 23 318"  result = 461

using System;
using System.Threading;
using System.Globalization;

namespace NameStringOfNumbers_Sum
{
    class StringOfNumbers_Sum
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            
            double sum = 0;
            Console.WriteLine("Give me the number sequence devided by 'space'(' ') like \"43 21.7 13.00007\" ");
            try
            {
                string numbers = Console.ReadLine();
                string[] num = numbers.Split(' ');

                for (int i = 0; i < num.Length; i++)
                {
                    if(num[i].IndexOf(',')>0)
                    {
                        throw new FormatException("Wrong decimal dot.");                       
                    }
                    sum += double.Parse(num[i]);
                }
                Console.WriteLine("Their sum: {0}",sum);
            }
            catch (FormatException )
            {
                Console.WriteLine("Wrong number format");
            }

        }
    }
}
