//Write a program that finds the most frequent number in an array. Example:
//    {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)
//
//First sort the array using my own implementation of Merge Sort with List<>
// than just for-loop for the sorted List<> and since the equal numbers are next to each other 
// I will only do one pass

using System;
using System.Collections;
using System.Collections.Generic;
class MostFrequentElement
{
    static List<int> mergeSort(List<int> unsorted)
    {
        if (unsorted.Count == 1)
        {
            return unsorted;
        }
        List<int> first = new List<int>();
        List<int> second = new List<int>();
        List<int> sorted = new List<int>();


        for (int i = 0; i < unsorted.Count; i++)
        {
            if (i < unsorted.Count / 2)
            {
                first.Add(unsorted[i]);
            }
            else
            {
                second.Add(unsorted[i]);
            }
        }
        first = mergeSort(first);
        second = mergeSort(second);

        first.TrimExcess();
        second.TrimExcess();
        int indexOfFirst = 0, indexOfSecond = 0;
        for (int i = 0; i < unsorted.Count; i++)
        {
            
            if (first[indexOfFirst] < second[indexOfSecond])
            {
                sorted.Add(first[indexOfFirst]);
                indexOfFirst++;
            }
            else
            {
                sorted.Add(second[indexOfSecond]);
                indexOfSecond++;
            }
            if (indexOfFirst >= first.Count)
            {
                for (int y = indexOfSecond; y < second.Count; y++)
                {
                    sorted.Add(second[y]);
                }
                break;
            }
            if (indexOfSecond >= second.Count)
            {
                for (int y = indexOfFirst; y < first.Count; y++)
                {
                    sorted.Add(first[y]);
                }
                break;
            }
        }
        sorted.TrimExcess();

        return sorted;
    }

    static void Main()
    {
        List<int> numbers = new List<int>();
        int next=0;
        
        while(int.TryParse(Console.ReadLine(),out next))
        {
            numbers.Add(next);
        }
        numbers=mergeSort(numbers);
        int numberChecked = numbers[0], timesRepeating = 0, maxRepeating = 1, maxRepeatinNumber = 0; ;
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numberChecked==numbers[i])
            {
                timesRepeating++;
            }
            else
            {
                timesRepeating = 1;                
                numberChecked = numbers[i];
            }
            if (timesRepeating>maxRepeating)
            {
                maxRepeating = timesRepeating;
                maxRepeatinNumber = numberChecked; 
            }            
        }
        Console.Write("The most frequent element is {0} - {1} times",maxRepeatinNumber,maxRepeating);        
    }
}


