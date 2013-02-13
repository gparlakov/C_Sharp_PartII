using System;


namespace CheckIfElementInArrayIsBigger
{
    public class RandomArray
    {
        static Random RandomGenerator = new Random();

        public void GenerateRandomArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (int)RandomGenerator.Next(1, 201);
            }
        }

        public void GenerateRandomArray(int[] array,int arrayLength,int rangeStart,int rangeEnd)
        {
            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = (int)RandomGenerator.Next(rangeStart, rangeEnd+1);
            }
        }

        public RandomArray()
        {

        }
        
        public RandomArray(int lenght,int rangeStart, int rangeEnd)
        {
            
        }
    }
}
