//Write a method that checks if the element at given position in given array of 
//integers is bigger than its two neighbors (when such exist)

using System;
using CheckIfElementInArrayIsBigger;


namespace CheckIfElementInArrayIsBigger
{
    public class CheckElementIfBigger
    {
        
        public static bool CheckNeighbouringElements(int[] arrayNumbers, int index)
        {
            if ((index > 0) && (index < arrayNumbers.Length-1) && (arrayNumbers[index] <= arrayNumbers[index-1] || arrayNumbers[index] <= arrayNumbers[index+1]))
            {
                return false;
            }
            if (index==0)
            {
                if (arrayNumbers[0] <= arrayNumbers[1])
                {
                    return false;
                }                
            }
            if (index==arrayNumbers.Length-1)
            {
                if (arrayNumbers[arrayNumbers.Length-1] <= arrayNumbers[arrayNumbers.Length-2])
                {
                    return false;
                }
            }
            return true;
        }

        static void Main()
        {
            int[] numbers = new int[1000];
            int indexOfElement;
            RandomArray Generator = new RandomArray();
            Generator.GenerateRandomArray(numbers);
            do
            {
                Console.WriteLine("I've generated a random array of lenght 1000 with the numbers from 1 to 200. \nWhat number shall we check? Give its index.");
            } while (!int.TryParse(Console.ReadLine(), out indexOfElement) || indexOfElement < 1 || indexOfElement > 1000);

            if (CheckNeighbouringElements(numbers,indexOfElement))
            {
                Console.WriteLine("The element {0} is bigger than element to the right {1} and to the left {2} ",numbers[indexOfElement],numbers[indexOfElement+1],numbers[indexOfElement-1]);  
            }
            else
            {
                Console.WriteLine("The element {0} is smaller than element to the right {1} or to the left {2} ", numbers[indexOfElement], numbers[indexOfElement + 1], numbers[indexOfElement - 1]);  
            }
        }
    }
}
