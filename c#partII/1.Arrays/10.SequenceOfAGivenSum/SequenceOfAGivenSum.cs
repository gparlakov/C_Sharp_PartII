//Write a program that finds in given array of integers a sequence of given sum S (if present). 
//Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}

//Reusing the code of SequenceOfMaximalSum only this time we search for one given sum
//It will search and show the sum of [1,2,3 ... lenghtOfArray] elements - i.e. if the sum
//is 10 and the element is only one and equal to 10 - program will show it 

using System;

class SequenceOfAGivenSum
{
    static void Main()
    {
        int lenghtOfArray, lenghtOfSum;
        int currentSum = 0, indexStart = 0, indexEnd = 0;
        int sumGiven = 0;

        do
        {
            Console.Write("How long will the array be? -> N =");
        } while (!int.TryParse(Console.ReadLine(), out lenghtOfArray)||lenghtOfArray<1);
        int[] numbers = new int[lenghtOfArray];

        do
        {
            Console.Write("What is the sum we are looking for -> sumGiven = ");
        } while (!int.TryParse(Console.ReadLine(), out sumGiven));
        

        //read the array from console
        for (int i = 0; i < lenghtOfArray; i++)
        {
            do
            {
                Console.Write("array[{0}]: ", i);
            } while (!int.TryParse(Console.ReadLine(), out numbers[i]));
        }

        int nextOfSum = 0;
        
        //calculate all the sums with lenght k = 2,3,4 ...n (lenght of array)
        //then save sum's index of start and end if it's equal to sumGiven
        for (lenghtOfSum = 1; lenghtOfSum <= lenghtOfArray; lenghtOfSum++)
        {
            for (int indexOfChecked = 0; indexOfChecked < lenghtOfArray - lenghtOfSum + 1; indexOfChecked++)
            {
                currentSum = numbers[indexOfChecked];
                for (nextOfSum = indexOfChecked + 1; nextOfSum < indexOfChecked + lenghtOfSum; nextOfSum++)
                {
                    currentSum += numbers[nextOfSum];
                }
                if (currentSum == sumGiven)
                {
                    indexStart = indexOfChecked;
                    indexEnd = nextOfSum;
                    sumGiven = currentSum;
                }
            }
        }        
        
        if (indexStart==indexEnd&&numbers[0]!=sumGiven )
        {
            Console.WriteLine("No such sum in this array");
        }
        else
        {
            Console.WriteLine("Sum is {0}", sumGiven);
            Console.WriteLine("Represented by the following members of the array");            
            do
            {
                Console.Write(numbers[indexStart] + " ");
                indexStart++;
            } while (indexStart<indexEnd);
            Console.WriteLine();
        }
    }
}
