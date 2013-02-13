//Write a program that finds the maximal sequence of equal elements in an array.
//Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.

using System;

class MaximalSequenceOfIntegersInArray
{
    static void Main()
    {
        int n;
        int currentSequence = 1, indexOfFirst, maxSequence = 0, indexStart = 0, indexOfEnd = 1;
        do
        {
            Console.WriteLine("How long will the array be?");
        } while (!int.TryParse(Console.ReadLine(), out n));
        int[] numbers = new int[n];

        //read the array from console
        for (int i = 0; i < n; i++)
        {
            do
            {
                Console.Write("array[{0}]: ", i);
            } while (!int.TryParse(Console.ReadLine(), out numbers[i]));
        }
        if (numbers.Length == 1)
        {
            Console.WriteLine("({0})", numbers[0]);
        }
        else
        {
            indexOfFirst = 0;
            //find the maximal sequece
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[indexOfFirst] == numbers[i])
                {
                    currentSequence++;
                    /*if we set the check to be only > - it shows the first of 
                     * the equally long sequencese (if any),if we set 
                     it to >= it shows the last of repeating sequences*/
                    if (currentSequence >= maxSequence)
                    {
                        maxSequence = currentSequence;
                        indexStart = indexOfFirst;
                        indexOfEnd = i;
                    }
                }
                else
                {

                    indexOfFirst = i;
                    currentSequence = 1;
                }

            }
            Console.WriteLine("The (last) longest sequence is:");


            Console.Write("{");
            for (int i = indexStart; i <= indexOfEnd; i++)
            {
                if (i == indexOfEnd)
                {
                    Console.Write(numbers[i]);
                }
                else
                {
                    Console.Write(numbers[i] + " ");
                }
            }
            Console.Write("}");
        }
    }
}