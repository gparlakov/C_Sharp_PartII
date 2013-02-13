//* Write a program that sorts an array of integers using 
//the merge sort algorithm (find it in Wikipedia).


using System;

class MergeSort
{
    static int[] mergeSort(int[] unsorted)
    {
        if (unsorted.Length<=1)
        {
            return unsorted;
        }
        
        int[] sorted = new int[unsorted.Length];
        int middle = (unsorted.Length) / 2;
        
        //split the unsorted array in two parts - left and right
        int[] left = new int[middle];
        int[] right = new int[unsorted.Length-middle];

        for (int i = 0; i < unsorted.Length; i++)
        {
            if (i<middle)
            {
                left[i] = unsorted[i];
            }
            else
            {
                right[i-middle]=unsorted[i];
            }
        }

        //
        left = mergeSort(left);
        right = mergeSort(right);
        int indexLeft = 0, indexRight = 0;
        for (int i = 0; i < unsorted.Length; i++)
        {
            
            if (left[indexLeft]<right[indexRight])
            {
                sorted[i] = left[indexLeft];
                indexLeft++;
            }
            else
            {
                sorted[i] = right[indexRight];
                indexRight++;
            }
            if (indexLeft>=left.Length)
            {
                i++;
                for (int n = indexRight; n < right.Length; n++,i++)
                {
                    sorted[i]=right[n];
                }
            }
            if (indexRight>=right.Length)
            {
                i++;
                for (int n = indexLeft; n < left.Length; n++, i++)
                {
                    sorted[i] = left[n];
                }
            }
        }

        return sorted;
    }
    
    
    static void Main()
    {
        //int[] numbers = { 5, 6, 7, -9, -10, 9, 99, -9999, -9, 5, 12, 124, -14, -168, -200}; 
        
        int lenghtOfArray;
        
        do
        {
            Console.Write("How long will the array be? -> N =");
        } while (!int.TryParse(Console.ReadLine(), out lenghtOfArray) || lenghtOfArray < 1);
        int[] numbers = new int[lenghtOfArray];


        //read the array from console
        for (int i = 0; i < lenghtOfArray; i++)
        {
            do
            {
                Console.Write("array[{0}]: ", i);
            } while (!int.TryParse(Console.ReadLine(), out numbers[i]));
        }
        
        numbers = mergeSort(numbers);
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i]+ " ");
        }

    }
}

