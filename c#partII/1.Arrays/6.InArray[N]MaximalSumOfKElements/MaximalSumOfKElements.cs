//Write a program that reads two integer numbers N and K and an array of N
//elements from the console. Find in the array those K elements that have maximal sum.

using System;

class MaximalSumOfKElements
{
    static void Main()
    {
        int n,k;
        int currentSum = 0, maxSum = int.MinValue, indexStart = 0, indexEnd = 1;
       
        do
        {
            Console.Write("How long will the array be? -> N =");
        } while (!int.TryParse(Console.ReadLine(), out n));
        int[] numbers = new int[n];
        do
        {
            Console.Write("K elements-> K = ");
        } while (!int.TryParse(Console.ReadLine(), out k));

        //read the array from console
        for (int i = 0; i < n; i++)
        {
            do
            {
                Console.Write("array[{0}]: ", i);
            } while (!int.TryParse(Console.ReadLine(), out numbers[i]));
        }

        
        for (int i = 0; i < n-k+1; i++)
        {
            for (int inside = i; inside < i+k; inside++)
            {
                currentSum+=numbers[inside];
            }
            if (currentSum>maxSum)
            {
                indexStart = i;
                indexEnd = i + k - 1;
                maxSum = currentSum;
            }
            currentSum = 0;            
        }

        Console.WriteLine(maxSum);
        for (int i = indexStart; i <= indexEnd; i++)
        {
            Console.Write(numbers[i]+" ");
        }
    }
}
