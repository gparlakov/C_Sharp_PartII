//Write a program that reads two numbers N and K and generates all the //combinations of K distinct elements from the set [1..N]. Example://    N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}

using System;
using System.Collections.Generic;

namespace Combinatorics
{
    class AllCombinations
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
            int n;
            int k;
            List<List<int>> combinationsOfMoreElements = new List<List<int>>();
            
            
            Console.WriteLine("We'll generate all combinations Lenght of [K] in an array of [1,2,3,4....N]");            
            do
            {
                Console.Write("Lenght of array 1....N  N=");
            } while (!int.TryParse(Console.ReadLine(),out n)||n<1);
            int[] numbers = new int[n]; //{ 1, 2, 3, 4, 5, 6, 7, 8, 9, };//10, 11, 12, 13, 14, 15 };

            do
            {
                Console.Write("Lenght of combination K=");
            } while (!int.TryParse(Console.ReadLine(), out k) || k > n);
            

            for (int i = 0; i < n; i++)
            {
                numbers[i] = i + 1;
            }
            

            combinationsOfMoreElements = Combinations(numbers, 0, k);
            Console.WriteLine("There are {0} combinations of {1} in that given array", combinationsOfMoreElements.Count, k);            
            for (int i = 0; i < combinationsOfMoreElements.Count; i++)
            {
                for (int y = 0; y < combinationsOfMoreElements[i].Count; y++)
                {
                    Console.Write(combinationsOfMoreElements[i][y] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}