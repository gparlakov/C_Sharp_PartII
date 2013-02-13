//Write a program that can solve these tasks://Reverses the digits of a number//Calculates the average of a sequence of integers//Solves a linear equation a * x + b = 0//        Create appropriate methods.//        Provide a simple text-based menu for the user to choose which task to solve.//        Validate the input data://The decimal number should be non-negative//The sequence should not be empty//a should not be equal to 0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Reverse_Average_Linear_Equasion
{
    public class ReverseAverageLinear_Equasion
    {
        const string endString = "Hit Any Key to return to main Menu";
        public static float AverageOfSequenceIntegers(int[] nums)
        {
            int result = 0;
            foreach (var num in nums)
            {
                result += num;
            }
            return (float)result/(float)nums.Length;
        }

        static void StartAverage()
        {
            Console.WriteLine("Write the numbers from the sequence one by one - leave empty for end");
            List<int> sequence = new List<int>();
            int next;
            string checkString="NotEmpty";
            do
            {

                do
                {
                    checkString=Console.ReadLine();
                    if (checkString==string.Empty)
                    {
                        Console.WriteLine("The average of theese numbers is \n{0}\n\n",AverageOfSequenceIntegers(sequence.ToArray()));                       
                        Console.WriteLine(endString);
                        Console.ReadLine();
                        return;
                    }
                } while (!int.TryParse(checkString,out next));

                sequence.Add(next);

            } while (true);
        }

        static int ReverseDigits(int number)
        {            
            string num = number.ToString();            
            StringBuilder result = new StringBuilder();
            for (int i = num.Length-1; i >=0; i--)
            {
                result.Append(num[i].ToString());
            }
            return int.Parse(result.ToString());
        }

        static void StartReverse()
        {
            int number;
            do
            {
                Console.WriteLine("Write down  the non-negative number:");
            }while(!int.TryParse(Console.ReadLine(),out number)||number<0);            
            Console.WriteLine("The reversed number is {0}\n\n{1}", ReverseDigits(number),endString);
            
            Console.ReadLine();
        }

        static float SolveLinear(int a, int b)
        {
            return (float)(-b) / (float)a;
        }

        static void StartLinear()
        {
            int a;
            int b;
            Console.Clear();
            Console.WriteLine("We'll solve the linear equasion ax+b=0 where a is not 0!");
            do
            {
                Console.WriteLine("a= ");
            } while (!int.TryParse(Console.ReadLine(),out a));

            do
            {
                Console.WriteLine("b= ");
            } while (!int.TryParse(Console.ReadLine(), out b));

            try
            {
                Console.WriteLine("\n X = {0}\n\n{1}", SolveLinear(a, b),endString);
                Console.ReadLine();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("A should not be 0! No Equasion otherwise!\n\n{0}",endString);
                Console.ReadLine();
            }
        }

        static void Main()
        {
            do
            {
                Console.WriteLine("\n     Menu:\n");
                Console.WriteLine("\n\t1.Reverse Digits Of A Number (not negative):");
                Console.WriteLine("\n\t2.Calculate Average Of a Sequence of Integers:");
                Console.WriteLine("\n\t3.Solve A Linear Equasion");
                Console.WriteLine("\n\t4.Quit\n\n\nChoose:");
                string choise = Console.ReadLine();
                Console.Clear();
                switch (choise)
                {
                    case "1":
                        {
                            StartReverse();
                            break;
                        }
                    case "2":
                        {
                            try
                            {
                                StartAverage();
                            }
                            catch (DivideByZeroException)
                            {
                                Console.WriteLine("No numbers to calculate average from  \n\n{0}",endString);
                                Console.ReadLine();
                            }
                            break;
                        }
                    case "3":
                        {
                            StartLinear();
                            break;
                        }
                    case "4":
                        {
                            return;

                        }

                    default:
                        break;
                }
                Console.Clear();
            } while (true);
        }

    }
}
