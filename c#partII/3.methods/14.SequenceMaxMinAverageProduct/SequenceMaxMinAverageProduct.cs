//Write methods to calculate minimum, maximum, average, 
//sum and product of given set of integer numbers. 
//Use variable number of arguments.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menu_Reverse_Average_Linear_Equasion;
using System.Numerics;



namespace _14.SequenceMaxMinAverageProduct
{
    class SequenceMaxMinAverageProduct
    {
        static Random generator = new Random();

        static int[] GenerateRandom(int length,int start,int end)
        {
            int[] result = new int[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = generator.Next(start, end + 1);
            }
            
            return result;
        }

        static int Minimum(IList<T> array)
        {
            int min = int.Parse(array[0].ToString());
            for (int i = 1; i < array.Length-1; i++)
            {
                if (array[i]<min)
                {
                    min = array[i];
                }
            }
            return min;
        }

        static T Maximum<T>(IList<T> array) where T: class
        {
            T max = array[0];    
            
            for (int i = 1; i < array.Count; i++)
            {
                //if (array[i] > max)
                //{
                //    max = array[i];
                //}
            }
            return max;
        }

        static BigInteger Product<T>(IList<T> numbers)
        {
            BigInteger result = 1;
            foreach (T num in numbers)
            {
                result *= BigInteger.Parse(num.ToString());
            }

            return result;
        }

        static void Main(string[] args)
        {
            int length = generator.Next(1000);
            int[] numbers = GenerateRandom(length, 1, 1000);
            long[] numbersLong = new long [ numbers.Length ];
            for (int i = 0; i < numbersLong.Length; i++)
            {
                numbersLong[i] = numbers[i];
            }
            Console.WriteLine("The average is {0}",ReverseAverageLinear_Equasion.AverageOfSequenceIntegers(numbers));
            Console.WriteLine("Minimum is {0}",Minimum(numbers));
            Console.WriteLine("Maximum is {0}",Maximum(numbers));
            Console.WriteLine("Product is {0}",Product(numbersLong));


        }
    }
}
