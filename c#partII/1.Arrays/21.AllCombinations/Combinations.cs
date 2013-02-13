using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinatorics
{
    class Combinations_
    {
        private int combinationLenght{get;set;}

        public List<List<int>> Combinations(int[] array, int startingIndex = 0, int combinationLenght = 2)
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

        public Combinations_(int[] array)
        {
            List<List<int>> listOfCombinations= new List<List<int>>();            
            listOfCombinations = Combinations(array, 0, combinationLenght);
        }
    }
}
