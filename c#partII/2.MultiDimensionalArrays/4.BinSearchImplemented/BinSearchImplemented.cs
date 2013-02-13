//Write a program, that reads from the console an array of N integers and an integer K, //sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 

using System;

class BinSearchImplemented
{
    static void Main()
    {
        int n=0,k = 3, index = 0;
        do
        {
            Console.WriteLine("How long should the array be?");
        }while(!int.TryParse(Console.ReadLine(),out n));

        do
        {
            Console.WriteLine("What is the number we are looking for? k = ");
        } while (!int.TryParse(Console.ReadLine(), out k));
        int[] numbers = new int[n];//{4, 16, -9, -56, 98, 56, 6, -7, 8, 4, 7, -10, 6};
        for (int i = 0; i < n; i++)
        {
            do
            {
                Console.Write("Element [{0}]: ",i);
            } while (!int.TryParse(Console.ReadLine(), out numbers[i]));
        }
        
        
        Array.Sort(numbers);
        index=Array.BinarySearch(numbers, k);
        Console.WriteLine("the largest number in the array which is ≤ K is:");
        if (index<0)
        {
            Console.WriteLine(numbers[-index-2]);
        }
        else
        {
            Console.WriteLine(numbers[index]);
        }


    }
}
