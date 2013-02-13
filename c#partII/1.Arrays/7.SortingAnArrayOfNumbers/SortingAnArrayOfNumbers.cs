//Sorting an array means to arrange its elements in increasing order. 
//Write a program to sort an array. Use the "selection sort" algorithm: 
//Find the smallest element, move it at the first position, find the smallest 
//from the rest, move it at the second position, etc.

using System;

class SortingAnArrayOfNumbers
{
    static void Main()
    {
        int n;    
       
        do
        {
            Console.Write("How long will the array be? -> N =");
        } while (!int.TryParse(Console.ReadLine(), out n));
        int[] numbers = new int[n];
        
        
        //read the array from console
        for (int i = 0; i < n; i++)
        {
            do
            {
                Console.Write("array[{0}]: ", i);
            } while (!int.TryParse(Console.ReadLine(), out numbers[i]));
        }

        int buffer = 0;
        for (int i = 0; i < n; i++)
		{
            for (int rest = i+1; rest < n; rest++)
            {
                if (numbers[rest]<numbers[i])
                {
                    buffer = numbers[i];
                    numbers[i] = numbers[rest];
                    numbers[rest] = buffer;
                }
            }			 
        }

        for (int i = 0; i < n; i++)
        {
            Console.Write(numbers[i]+" ");
        }

    }
}