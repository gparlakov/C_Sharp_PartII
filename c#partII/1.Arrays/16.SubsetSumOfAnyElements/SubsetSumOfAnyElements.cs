//* We are given an array of integers and a number S. //Write a program to find if there exists a subset of the //elements of the array that has a sum S. //Example://    arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6)


using System;
using System.Collections.Generic;



class SubsetSumOfAnyElements
{
    static void Main(string[] args)
    {
        int[] numbers = {2, 1, 2, 4, 3, 5, 2, 6};//{2,3,5,77,18,97,641,5,6,9,7,5,2,1,4,9,5,4,6,9 };
        int subsetLength = 2;
        int currentSum = 0;

        //change the lenght of the sub set = 2,3,4 .. all elements
        for (subsetLength = 2; subsetLength < numbers.Length; subsetLength++)
        {
            //change starting point of subset 0,1,2...all-subset lenght + 1
            for (int i = 0; i <= numbers.Length - subsetLength; i++)
            {
                //every time we jump over one of the elements
                for (int jumpOver = 0; jumpOver < numbers.Length; jumpOver++)
                {
                    //calculate the subset
                    for (int indexFirst = i; indexFirst < i + subsetLength; indexFirst++)
                    {

                    }
                }
            }
        }
    }
}