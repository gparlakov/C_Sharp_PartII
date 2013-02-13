using System;

    class CountNumerOfAppearencesInAnArray
    {
        static Random RandomGenerator = new Random();

        static void GenerateRandomArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (int)RandomGenerator.Next(1, 201);
            }
        }
        
        static void CountRepeatingInArray(int[] array, int number)
        {
            int counter=0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i]==number)
                {
                    counter++;
                }
            }
            Console.WriteLine("Numer {0} repeats {1} times.",number,counter);
        }


        static void Main()
        {
            int[] numbers = new int[1000];
            int numberRepeating;
            GenerateRandomArray(numbers);
            do{
                Console.WriteLine("I've generated a random array of lenght 1000 with the numbers from 1 to 200. \nWhat number shall we check?");
            }while(!int.TryParse(Console.ReadLine(),out numberRepeating)||numberRepeating<1||numberRepeating>200);

            CountRepeatingInArray(numbers, numberRepeating);
        }
    }
