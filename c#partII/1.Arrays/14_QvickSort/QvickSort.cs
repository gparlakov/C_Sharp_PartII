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
            if (array[leng] != null)
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
        if (arrayToSort.Length <= 1)
        {
            return arrayToSort;
        }
        //I chose the pivot to be the first element
        string pivot = arrayToSort[0];       

        //creating two strings which will be populated
        // and later cleared of the null elements
        string[] left = new string[arrayToSort.Length - 1];
        string[] right = new string[arrayToSort.Length - 1];
        
        //if the first char of each of the elements(strings) is lower or equal
        //to the first char of the pivot (but is not the pivot itself) 
        //it goes in the left array otherwise it goes in the right
        int indexLeft = 0, indexRight = 0;
        for (int i = 0; i < arrayToSort.Length; i++)
        {
            if (arrayToSort[i].CompareTo(pivot) <= 0 && i != 0)
            {
                left[indexLeft] = arrayToSort[i];
                indexLeft++;
            }
            else if (arrayToSort[i].CompareTo(pivot) > 0)
            {
                right[indexRight] = arrayToSort[i];
                indexRight++;
            }
        }
        
        //since we have two arrays with some elements and some null elements 
        //we need to clear the null elements and
        string[] leftCleared = new string[lengthToNull(left)];
        //Array.Clear(leftCleared, 0, leftCleared.Length);
        string[] rightCleared = new string[lengthToNull(right)];
        //Array.Clear(rightCleared,0,rightCleared.Length);
        
        //if the cleared arrays are populated (not empty)
        //I call recursively the quickSort
        //otherwise skip the empty array
        if (lengthToNull(left) > 0)
        {
            leftCleared = clearNull(left, lengthToNull(left));
            leftCleared = quickSort(leftCleared);
        }

        if (lengthToNull(right) > 0)
        {
            rightCleared = clearNull(right, lengthToNull(right));
            rightCleared = quickSort(rightCleared);
        }

        string[] sortedArray= new string[arrayToSort.Length];
        //Array.Clear(sortedArray, 0, sortedArray.Length);
        int index = 0;
        indexLeft = indexRight = 0;
        
        if (leftCleared.Length > 0)
        {
            while (leftCleared[indexLeft] != null)
            {
                sortedArray[index] = leftCleared[indexLeft];
                index++;
                indexLeft++;

                if (indexLeft == leftCleared.Length)
                {
                    break;
                }
            }
        }
        //insert pivot after all lesser or equal elements are inserted
        //they are checked above when creating the left and right arrays
        sortedArray[index] = pivot;
        index++;
        if (rightCleared.Length > 0)
        {
            while (rightCleared[indexRight] != null)
            {
                sortedArray[index] = rightCleared[indexRight];
                index++;
                indexRight++;
                if (indexRight == rightCleared.Length)
                {
                    break;
                }
            }
        }
        //Array.Clear(left, 0, left.Length);
        //Array.Clear(right,0,right.Length);
        //Array.Clear(leftCleared,0,leftCleared.Length);
        //Array.Clear(rightCleared, 0, rightCleared.Length);
        //Array.Clear(arrayToSort, 0, arrayToSort.Length);
        return sortedArray;
    }

    static void Main()
    {
        //string[] strings = { "Amanda", "Zagorka", "Ivana","Petq", "quick", "bitch", "algoritm", "Ariana", "Manila","Kameniza", "Kamenica Tymno","New Zealand","Old Zealand","Middle Earth","Mallorca","Ibisa","TiSaIbi","AndSoOn","AndSoOff",};
        int length;
        
        do
        {
            Console.WriteLine("how long will the string be?");            
        } while (!int.TryParse(Console.ReadLine(),out length)||length<1);
        string[] strings = new string[length];

        for (int i = 0; i < length; i++)
        {
            strings[i]=Console.ReadLine();
        }
        Console.WriteLine();
        string[] sortedStrings = new string[strings.Length];
        sortedStrings = quickSort(strings);
        for (int i = 0; i < sortedStrings.Length; i++)
        {
            Console.WriteLine(sortedStrings[i]);            
        }
    }
}