//Write a program that shows the binary representation
//of given 16-bit signed integer number (the C# type short).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecimalToBinary;
namespace BinaryRepresentation
{
    class BinaryRepresentation
    {
        static string BinaryRep(short number)
        {
            string result=null;
            if (number>=0)
            {
                result = DecimalToBinary.DecimalToBinary.DecimalToBin(number);
                if (result.Length < 15)
                {
                    String temp = new String('0', 15 - result.Length);
                    result = temp + result;
                }
                result = "0" + result;
            }
            else
            {
                result = DecimalToBinary.DecimalToBinary.DecimalToBin(Math.Abs(short.MinValue - number));
                if (result.Length < 15)
                {
                    String temp = new String('0', 15 - result.Length);
                    result = temp + result;
                }
                result = "1" + result;
            }
            return result;
        }
        
        static void Main()
        {
            short number=-32000;
            Console.WriteLine("{0,7} : {1}",number,BinaryRep(number));
            number = -18;             
            Console.WriteLine("{0,7} : {1}", number, BinaryRep(number));
            number = -256;            
            Console.WriteLine("{0,7} : {1}", number, BinaryRep(number));
            number = -1002;
            Console.WriteLine("{0,7} : {1}", number, BinaryRep(number));
            number = 0;              
            Console.WriteLine("{0,7} : {1}", number, BinaryRep(number));
            number = 18;              
            Console.WriteLine("{0,7} : {1}", number, BinaryRep(number));
            number = 256;             
            Console.WriteLine("{0,7} : {1}", number, BinaryRep(number));                                      
            number = 1598;             
            Console.WriteLine("{0,7} : {1}", number, BinaryRep(number));
            number = 14556;           
            Console.WriteLine("{0,7} : {1}", number, BinaryRep(number));
        }
    }
}
