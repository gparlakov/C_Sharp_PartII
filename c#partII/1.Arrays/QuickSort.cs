//Write a program that sorts an array of strings using 
//the quick sort algorithm (find it in Wikipedia).

using System;

class QuickSort
{
    static int lengthToNull(string[] array)
    {
        int leng = 0;
        while (leng < (array.Length))
        {
            if (array[leng]!=null)
            {
                leng++;
            }
            else
            {
                break;
            }
        }
        return leng;
    }
        
    static string[] clearNull(string[] toBeCleared, int length)
    {
        
        string[] resultArray = new string[length];

        for (int i = 0; i < length; i++)
        {
            resultArray[i] = toBeCleared[i];
        }
        return resultArray;	  
    }
    
    static string[] quickSort(string[] arrayToSort)
    {
        if (arrayToSort.Length<=1)
        {
            return arrayToSort;
        }
        string pivot = arrayToSort[0];
        //if (arrayToSort.Length==2)
        //{
        //    if (arrayToSort[0][0]>arrayToSort[1][0])
        //    {
        //        string buffer;

        //    }
            
        //}
        
        string[] left = new string[arrayToSort.Length-1];
        string[] right = new string[arrayToSort.Length-1];

        //char middleChar, last;
        //middleChar=arrayToSort[middle][0];
        //last = arrayToSort[arrayToSort.Length - 1][0];
        //if (middleChar > last)
        //{
        //    string buffer = arrayToSort[middle];
        //    arrayToSort[middle] = arrayToSort[arrayToSort.Length - 1];
        //    arrayToSort[arrayToSort.Length - 1] = buffer;
        //}

        int indexLeft = 0, indexRight = 0;
        for (int i = 0; i < arrayToSort.Length; i++)
        {
            if (arrayToSort[i][0]<=pivot[0]&&i!=0)
            {
                left[indexLeft] = arrayToSort[i];
                indexLeft++;
            }
            else if (arrayToSort[i][0] > pivot[0])
            {
                right[indexRight] = arrayToSort[i];
                indexRight++;
            }
        }
        //since we have two arrays with some elements and some null elements 
        //we need to clear the null elements and

        string[] leftCleared = new string[lengthToNull(left)];
        string[] rightCleared = new string[lengthToNull(right)];
        if (lengthToNull(left) > 0)
        {
            leftCleared = clearNull(left,lengthToNull(left));
            leftCleared = quickSort(leftCleared);
        }

        if (lengthToNull(right)>0)
        {
            rightCleared = clearNull(right,lengthToNull(right));
            rightCleared = quickSort(rightCleared);
        }
            
        int index = 0;
        indexLeft = indexRight = 0;
        //TODO insert pivot
        if (leftCleared.Length>0)
        {
            while (leftCleared[indexLeft] != null)
            {
                arrayToSort[index] = left[indexLeft];
                index++;
                indexLeft++;

                if (indexLeft == leftCleared.Length)
                {
                    break;
                }
            }
        }
        arrayToSort[index] = pivot;
        index++;
        if (rightCleared.Length>0)
        {
            while (rightCleared[indexRight] != null)
            {
                arrayToSort[index] = right[indexRight];
                index++;
                indexRight++;
                if (indexRight == rightCleared.Length)
                {
                    break;
                }
            }            
        }
        return arrayToSort;
    }
    
    static void Main()
    {
        string[] strings = { "amanda", "Zagorka", "Ivana", 
        "petq", "quick", "bitch", "algoritm", "Ariana", "Manila", 
        "Kameniza", "Kamenica Tymno","New Zealand","Old Zealand","Middle Earth",
        "Mallorca","Ibisa","TiSaIbi","AndSoOn","AndSoOff",}; 
        strings=quickSort(strings);
        Console.ReadLine();
    }
}