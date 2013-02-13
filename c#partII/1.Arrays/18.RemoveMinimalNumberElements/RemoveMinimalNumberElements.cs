//* Write a program that reads an array of integers and 
//removes from it a minimal number of elements in such way 
//that the remaining array is sorted in increasing order. 
//Print the remaining sorted array. Example:
//    {6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5}

using System;
using System.Collections.Generic;
using System.Linq;


class RemoveMinimalNumberElements
{
    static List<List<int>> Combinations(int[] array, int startingIndex = 0, int combinationLenght = 2)
    {

        List<List<int>> combinations = new List<List<int>>();
        if (combinationLenght == 2)
        {

            int combinationsListIndex = 0;
            for (int arrayIndex = startingIndex; arrayIndex < array.Length; arrayIndex++)
            {

                for (int i = arrayIndex + 1; i < array.Length; i++)
                {

                    //add new List in the list to hold the new combination
                    combinations.Add(new List<int>());

                    //add the starting index element from "array"
                    combinations[combinationsListIndex].Add(array[arrayIndex]);
                    while (combinations[combinationsListIndex].Count < combinationLenght)
                    {

                        //add until we come to the length of the combination
                        combinations[combinationsListIndex].Add(array[i]);
                    }
                    combinationsListIndex++;
                }

            }

            return combinations;
        }

        List<List<int>> combinationsofMore = new List<List<int>>();
        for (int i = startingIndex; i < array.Length - combinationLenght + 1; i++)
        {
            //generate combinations of lenght-1(if lenght > 2 we enter into recursion)
            combinations = Combinations(array, i + 1, combinationLenght - 1);

            //add the starting index Elemetn in the begginnig of each newly generated list
            for (int index = 0; index < combinations.Count; index++)
            {
                combinations[index].Insert(0, array[i]);
            }

            for (int y = 0; y < combinations.Count; y++)
            {
                combinationsofMore.Add(combinations[y]);
            }
        }

        return combinationsofMore;
    }


    static void Main()
    {
        int[] numbers = new int[] { 6, 1, 4, 2, 3, 0, 2, 2, 3, 6, 4, 5 };
        //int maxNumberElements = 0, indexOfLargerList = -1;
        bool increasingOrder = true;
        List<List<int>> sequences = new List<List<int>>();

        //I generata all possible combinations starting from the longest one
        for (int i = numbers.Length; i >0 ; i--)
        {
            
            //check if among the sequences generated there is an ascending oreder array/list/
            //is there is - since I go from the longest sequences down it is the longest possible 
            //(or the first of them) so I print it out and terminate the program
            sequences = Combinations(numbers, 0, i);
            for (int indexSequence = 0; indexSequence < sequences.Count; indexSequence++)
            {
                increasingOrder = true;
                for (int indexCombination = 1; indexCombination < sequences[indexSequence].Count ; indexCombination++)
                {
                    if (sequences[indexSequence][indexCombination] < sequences[indexSequence][indexCombination-1])
                    {
                        increasingOrder = false;
                        break;
                    }                    
                }
                if (increasingOrder)
                {
                    Console.WriteLine("The longest increasing order array is {0} long :",sequences[indexSequence].Count);
                    for (int ind = 0; ind < sequences[indexSequence].Count; ind++)
                    {
                        Console.Write(sequences[indexSequence][ind]+" ");
                    }
                    return;
                }
            }
        }

        
    }
}
