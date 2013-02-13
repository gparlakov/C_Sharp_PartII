//Write a program that finds the sequence of maximal sum in given array. Example://    {2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}//    Can you do it with only one loop (with single scan through the elements of the array)? - I Can't Yet :)
using System;


class SequenceOfMaximalSumam
{
    static void Main()
    {
        int lenghtOfArray, lenghtOfSum;
        int currentSum = 0, maxSum = int.MinValue, indexStart = 0, indexEnd = 1;

        do
        {
            Console.Write("How long will the array be? -> N =");
        } while (!int.TryParse(Console.ReadLine(), out lenghtOfArray)||lenghtOfArray<1);
        int[] numbers = new int[lenghtOfArray];

        
        //read the array from console
        for (int i = 0; i < lenghtOfArray; i++)
        {
            do
            {
                Console.Write("array[{0}]: ", i);
            } while (!int.TryParse(Console.ReadLine(), out numbers[i]));
        }

        
        int nextOfSum=0;
        maxSum = numbers[0];
        //calculate all the sums with lenght k = 2,3,4 ...n (lenght of array)
        //then save the max sum and it's index of start and end 
        for (lenghtOfSum = 1; lenghtOfSum <= lenghtOfArray; lenghtOfSum++)
        {
            for (int indexOfChecked = 0; indexOfChecked < lenghtOfArray - lenghtOfSum +1; indexOfChecked++)
            {
                currentSum = numbers[indexOfChecked];
                for (nextOfSum = indexOfChecked + 1; nextOfSum < indexOfChecked + lenghtOfSum; nextOfSum++)
                {
                    currentSum += numbers[nextOfSum];
                }
                if (currentSum > maxSum)
                {
                    indexStart = indexOfChecked;
                    indexEnd = nextOfSum;                               
                    maxSum = currentSum;
                }
            }
        }
        Console.WriteLine("Sum is {0}", maxSum);
        for (int i = indexStart; i < indexEnd; i++)
        {
            Console.Write(numbers[i]+" ");
        }
        Console.WriteLine();
    }
}