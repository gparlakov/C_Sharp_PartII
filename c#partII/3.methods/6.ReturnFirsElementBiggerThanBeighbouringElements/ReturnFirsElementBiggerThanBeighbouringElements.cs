//Write a method that returns the index of the first element in array //that is bigger than its neighbors, or -1, if there’s no such element.//Use the method from the previous exercise.
using System;
using CheckIfElementInArrayIsBigger;

class ReturnFirsElementBiggerThanBeighbouringElements
{
    private static int FirstBiggerNeighbour(int[] numbers)
    {
        int indexer = -1;
        for (int i = 0; i <= numbers.Length - 1; i++)
        {
            
            if (CheckElementIfBigger.CheckNeighbouringElements(numbers, i))
            {
                indexer = i; 
                break;
            }
           
        }
        return indexer;
    }

    static void Main()
    {
        int[] numbers = new int[15] { 2, 2, 2, 2,42, 2, 2, 2, 2, 2, 2, 2, 2, 2,2};
        int indexOfFirst;
        //RandomArray RandomArrayGenerator = new RandomArray();
        //RandomArrayGenerator.GenerateRandomArray(numbers);
        Console.WriteLine("The index of the first element that us bigger than its neighbours is:");
        indexOfFirst = FirstBiggerNeighbour(numbers);

        if (indexOfFirst >= 0)
        {
            Console.WriteLine(indexOfFirst);
            Console.WriteLine("Element({0}): {1}", indexOfFirst, numbers[indexOfFirst]);
        }
        else
        {
            Console.WriteLine("No such element");
        }
        
    }
  
    
}
