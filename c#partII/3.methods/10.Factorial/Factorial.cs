//Write a program to calculate n! for each n in the range [1..100]. 
//Hint: Implement first a method that multiplies a number represented 
//as array of digits by given integer number. 


using System;
using AddTwoLargeIntegers;

namespace Factorials
{
    public static class Factorial
    {
        
        //the method if 0 and 1 return is easy
        //after that - multiply by 5 is 5 times adding number to itself
        // (4 times actually)
        public static string Multiply(byte[] number, string multiplicator)
        {
            int repetitions = int.Parse(multiplicator);
            string result=null;
            if (repetitions == 0)
            {
                return "0";
            }
            else if (repetitions == 1)
            {
                number = ReverseArray(number);
                for (int i = number.Length-1; i >=0 ; i--)
                {
                    result += number[i];
                }
                return result;
            }

            // I reuse the method from AddTwoLargeIntegers
            result = AddTwoLongIntegers.AddIntegers(number, number);
            //now we have mutliplication by 2            
            for (int i = 1; i < repetitions - 1; i++)
            {
                result = AddTwoLongIntegers.AddIntegers(ToByteArray(result), number);
            }
            return result;
        }
        
        //self explanatory name I think :)
        public static byte[] ReverseArray(byte[] array)
        {
            byte[] reversedArray = new byte[array.Length];
            for (int i = array.Length - 1; i >= 0; i--)
            {
                reversedArray[array.Length -1 - i] = array[i];
            }
            return reversedArray;
        }
        

        // turn string to byte[]
        public static byte[] ToByteArray(string number)
        {
            byte[] resultArray = new byte[number.Length];
           
            for (int i = 0; i < number.Length; i++)
            {
                resultArray[i] = (byte)(number[i]-'0');
            }

            return resultArray;
        }
        
        static void Main(string[] args)
        {
            string factorielTemp= null;
            for (int i = 1; i < 101; i++)
            {
                factorielTemp = 1.ToString();
                for (int factoriel = 1; factoriel <= i; factoriel++)
                {
                    factorielTemp = Multiply(ToByteArray(factorielTemp), factoriel.ToString());
                }
                Console.WriteLine("Factorial of {0} is {1}",i,factorielTemp);                
            }       

        }
    }
}
