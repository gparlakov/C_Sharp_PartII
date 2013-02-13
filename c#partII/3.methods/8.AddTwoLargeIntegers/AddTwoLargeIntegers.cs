//Write a method that adds two positive integer numbers represented as arrays 
//of digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]).
//Each of the numbers that will be added could have up to 10 000 digits.

using System;



namespace AddTwoLargeIntegers
{
    public class AddTwoLongIntegers
    {

        static int SimpleAdd(char first, char second)
        {
           int result= ((first - '0') + (second - '0'));
           return result;
        }

        public static string ReverseArray(byte[] array)
        {
            string reversedArray=null;
            for (int i = array.Length-1; i>=0 ; i--)
            {
                reversedArray += array[i];
            }
            return reversedArray;
        }

        public static string ReverseArray(string str)
        {
            string reversedArray = null;
            for (int i = str.Length-1; i >= 0; i--)
            {
                reversedArray += str[i];
            }
            return reversedArray;
        }

        public static string AddIntegers(byte[] first, byte[] second)
        {
            string result=null,firstNum=null,secondNum = null;
            
            firstNum = ReverseArray(first);
            secondNum = ReverseArray(second);
            char longer;
            
            //get the length of the smaller/shorter array and lengthLonger of the longer array
            int length; 
            int lengthLonger;
            if (first.Length>second.Length)
            {
                lengthLonger=first.Length;
                length=second.Length;
                longer='f';		 
            }
            else 
            {
                lengthLonger=second.Length;
                length = first.Length;
                longer='s';
            }
            int temp=0,index;
            byte oneInMind = 0;

            //add the reversed arrays from lowest index to the edn of the smaller/shorter array
            for (index = 0; index < length; index++)
            {
                temp = SimpleAdd((char)firstNum[index],(char)secondNum[index]) + oneInMind;
                if (temp >= 10)
                {
                    oneInMind = 1;
                    temp -= 10;
                }
                else
                {
                    oneInMind = 0;
                }
                result += temp;
            }

            //add remainig digits from the longger number
            for (int i = length; i < lengthLonger; i++)
            {
                if (longer == 'f')
                {
                    temp = SimpleAdd((char)firstNum[i], (char)'0') + oneInMind;
                }
                else
                {
                    temp = SimpleAdd((char)secondNum[i], (char)'0') + oneInMind;
                }
 
                if (temp >= 10)
                {
                    oneInMind = 1;
                    temp -= 10;
                }
                else
                {
                    oneInMind = 0;
                }
                result += temp;
            }

            //add the one in mind if it's == 1
            if (oneInMind==1)
            {
                result += oneInMind;
            }

            return ReverseArray(result);
        }
        
        static void Main()
        {
            byte[] secondNumber = new byte[] { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 };
            byte[] firstNumber = new byte[] { 0 };// { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 0 };//;//, 9, 4, 6, 3, 1 };//{ 1, 2, 3, 4, 5, 9, 7, 5, 6, 9, 4, 6, 3, 1 };
            
            String result = AddIntegers(firstNumber, secondNumber);
            Console.WriteLine(result);

        }
    }
}
