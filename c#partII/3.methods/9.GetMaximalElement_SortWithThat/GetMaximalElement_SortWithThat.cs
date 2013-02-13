//Write a method that return the maximal element in a portion 
//of array of integers starting at given index. 
//Using it write another method that sorts an array in 
//ascending / descending order.


using System;
using CheckIfElementInArrayIsBigger;

namespace GetMaximalElementSortWithThat
{
    public class GetMaximalElement_SortWithThat
    {
        static int returnMaximum(int[] array, int startingIndex, int range)
        {
            int result = 0;
            for (int i = startingIndex; i < (array.Length) && i < (startingIndex+range); i++)
            {
                if (array[i]>=array[result])
                {
                    result = i;
                }
            }
            return result;
        }
        
        
        static void Main()
        {
            int[] numbers = new int[20000];
            RandomArray randomGenerator = new RandomArray();
            //random array of int-s with range from -100000 to 100000 included
            //gets slow over 20000
            randomGenerator.GenerateRandomArray(numbers,numbers.Length,-100000,100000);

            for (int i = numbers.Length-1; i > 0; i--)
            {
                int temp = numbers[i];
                int indexOfMaximum;
                indexOfMaximum = returnMaximum(numbers,0,i+1);
                numbers[i] = numbers[indexOfMaximum];
                numbers[indexOfMaximum] = temp;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }
}
