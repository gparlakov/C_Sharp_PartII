//Write a method that reverses the digits of given decimal number.
//Example: 256  652

using System;

namespace ReverseDigits
{
    class ReverseDigits
    {
        public static string ReverseDigit(string number)
        {
            string resultNumber=null;// = new char[number.Length];
            for (int i = number.Length-1; i >=0; i--)
            {
                resultNumber+= number[i];
            }            
            return resultNumber;
        }
        
        static void Main()
        {
            Console.WriteLine("Give me a number and I will reverse it.");
            string num = Console.ReadLine();
            string reversedNum = ReverseDigit(num);
            Console.WriteLine(reversedNum);   
        }
    }
}
