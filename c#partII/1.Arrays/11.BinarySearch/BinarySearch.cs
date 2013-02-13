//Write a program that finds the index of given element in a 
//sorted array of integers by using the binary search algorithm (find it in Wikipedia).

using System;

class BinarySearch
{
        
    static void Main()
    {
        int[] numbers = new int[100000];
        int searchedElement = 0, indexStart = 0;
        int index = 0, indexFinish = numbers.Length - 1;
        
        // int[] iterations = new int[numbers.Length];
        //the commented lines were used to find the maximum number of iterations done by 
        //the binary search and as they should be  = 1+log2(nummbers.Lenght)
        //for my algorythm I use 2+log2(...) because of line 43 - adds 1 iteration here and there

        do
        {
            Console.WriteLine("what is the element we are looking for?");
        }while (!int.TryParse(Console.ReadLine(),out searchedElement));
       

        //maximum number of iterations (repetitions of the loop/method) 
        //before we determine that there is no such element in the array at hand
        //because if there is no such element and it is left unchecked 
        //the loop will hop up and down endlessly 
        //e.g. if ew look for 3 here it will go down from 4
        //and up from 2 and keep searching

        int iterations = (int)(Math.Log(numbers.Length,2))+2;
        //int iterationsBackup=0;

        //filling the array with it's index - it's sorted
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i*2;
        }
        

        //for (int i = 0; i < iterations.Length; i++)
        //{
        //   searchedElement =numbers[i];
        index = numbers.Length / 2;
        indexFinish = numbers.Length - 1;
        indexStart = 0;
        while (searchedElement != numbers[index])
        {
            //iterations[i]++;
            //if (searchedElement == 50003)
            //{
            //    Console.WriteLine();
            //}
            if (numbers[index] > searchedElement)
            {
                indexFinish = index;
                index = indexFinish - 1 - (indexFinish - indexStart) / 2;
            }
            else
            {
                indexStart = index;
                index = indexStart + (indexFinish - indexStart + 1) / 2;
            }
            iterations--;
            if (iterations<0)
            {
                Console.WriteLine("There is no such number in the given array");
                break;
            }
            //iterationsBackup++;
        }        
        //}

        if (iterations>=0)
        {
            Console.WriteLine("The index of {0} in the array is {1}",searchedElement, index);
            Console.WriteLine("Iterations = {0}", (int)Math.Log(numbers.Length,2) - iterations + 2);
            //Console.WriteLine(iterationsBackup);     
        }           
        
        
        //int maximum = 0;
        //for (int i = 0; i < iterations.Length; i++)
        //{
        //    if (maximum<iterations[i])
        //    {
        //        maximum = iterations[i];
        //    }
        //}
    }
}