//Write a program that finds all prime numbers in the range [1...10 000 000]. 
//Use the sieve of Eratosthenes algorithm (find it in Wikipedia).

using System;
using System.Collections.Generic;

class PrimeNumbersBySieveOfEratosthenes
{
        
    static void Main()
    {
        
        ulong length = 10000001;
        bool[] numbers = new bool[length];
        int counter = 0;
        char yes;
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = true;
        }
               
        int sqrtLength =(int)Math.Sqrt(length) ;    
        for (int index = 2; index<sqrtLength ; index++)
        {
            if (numbers[index]!=false)
            {
                for (int next = index+1; next < numbers.Length; next++)
			    {
                    if (next % index == 0)
                    {
                        numbers[next]=false;                    
                    }			 
			    }
            }
        }
        for (int i = 2; i < numbers.Length; i++)
        {
            if (numbers[i])
            {
                counter++;
            } 
        }

        Console.WriteLine("In the interval 0-{0} the prime numbers are {1}",numbers.Length-1,counter);

        Console.WriteLine("Do you want to print'em?");
        
        do
        {
            Console.WriteLine("key :(Y)es or No: Any other key"); 
        } while (!char.TryParse(Console.ReadLine(),out yes)||!(yes=='y'||yes=='n'));

        switch (yes)
        {
            case 'y':
            case 'Y':
                {
                    for (int i = 1; i < numbers.Length; i++)
                    {
                        if (numbers[i])
                        {
                            Console.Write("|{0}", i);
                        }
                    }
                    break;
                }

            default: break;
        
        }
        
    }
}
