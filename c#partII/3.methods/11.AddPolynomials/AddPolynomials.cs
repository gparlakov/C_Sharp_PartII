//Write a method that adds two polynomials. Represent them as 
//arrays of their coefficients as in the example below:
//        x2 + 5 = 1x2 + 0x + 5 


using System;

namespace AddPolynomials
{
    class AddTwoPolynomials
    {
        private static void PrintPolynom(int[] result)
        {
            for (int i = result.Length - 1; i > 0; i--)
            {
                if(result[i]!=0)
                {
                    Console.Write(" {0}*x{1} ", result[i], i);
                    if (i>0&&result[i-1]<0)
                    {
                        Console.Write('-');
                    }
                    else if(i>0)
                    {
                        Console.Write('+');
                    }
                }
            }
            Console.WriteLine(result[0]);
        }
        //static int[] Reverse(int[] array)
        //{
        //    int[] result = new int[array.Length];
        //    for (int i = array.Length-1; i>=0; i --)
        //    {
        //        result[array.Length - 1 - i] = array[i];
        //    }
        //    return result;
        //}


        //takes the coefficients and writes them in an array 
        // index 0 equals x power of 0, index 2- x*x, index 3 - x*x*x (x3)
        private static void GetCoefficients(int power, int[] arrayCoefficients)
        {
            for (int i = power; i >= 0; i--)
            {
                do
                {
                    Console.WriteLine("X Power of {0}", i);
                }
                while (!int.TryParse(Console.ReadLine(), out arrayCoefficients[i]));
            }
        }

        static int[] MultiplyPolinoms(int[] first, int[] second)
        {
            
            int[] result = new int[first.Length+second.Length-1];
            result.Initialize();
            for (int i = 0; i < first.Length; i++)
            {
                for (int y = 0; y < second.Length; y++)
                {
                    result[i + y] += first[i] * second[y];
                }
            }

            return result;
        }


        static int[] SubstractPolynoms(int[] first, int[] second)
        {
            int length = first.Length;
            int shorterLenght = second.Length;
            if (first.Length < second.Length)
            {
                length = second.Length;
                shorterLenght = first.Length;
            }
            int[] result = new int[length];


            //where the two polinomials have both coefficiends 
            //substract them( second is always with  sign '-'
            for (int i = shorterLenght - 1; i >= 0; i--)
            {
                result[i] = first[i] - second[i];
            }

            //second is always with  sign '-'
            for (int i = length - 1; i >= shorterLenght; i--)
            {
                if (first.Length == length)
                {
                    result[i] = first[i];
                }
                else
                {
                    result[i] = -second[i];
                }
            }

            return result;
        }

        static int[] SumPolynoms(int[] first, int[] second)
        {
            int length = first.Length;
            int shorterLenght = second.Length;
            if (first.Length < second.Length)
            {
                length = second.Length;
                shorterLenght = first.Length;
            }
            int[] result = new int[length];

            //where the two polinomials have both coefficiends 
            //add them both
            for (int i = shorterLenght - 1; i >= 0; i--)
            {
                result[i] = first[i] + second[i];
            }

            //where the longer polinomial only has coefficients
            // add only them
            for (int i = length - 1; i >= shorterLenght; i--)
            {
                if (first.Length == length)
                {
                    result[i] = first[i];
                }
                else
                {
                    result[i] = second[i];
                }
            }

            return result;
        }
        static void Main()
        {
            int power = 0;
            Console.WriteLine("About the first polynom:");
            do
            {
                Console.WriteLine("What is the higher power of x?");
            } while (!int.TryParse(Console.ReadLine(), out power) || power < 0);

            int[] firstPolynom = new int[power + 1];

            GetCoefficients(power, firstPolynom);

            Console.WriteLine("Now the second");
            do
            {
                Console.WriteLine("What is the higher power of x?");
            } while (!int.TryParse(Console.ReadLine(), out power) || power < 0);

            int[] secondPolynom = new int[power + 1];
            GetCoefficients(power, secondPolynom);

            //                         p,px,px2,px3
            //int[] firstPolynom = new int[] { 1, 2, 3 }; 
            //int[] secondPolynom = new int[] { 1, 2 };
            int[] result = SumPolynoms(firstPolynom, secondPolynom);            
            
            result = SumPolynoms(firstPolynom, secondPolynom);
            Console.WriteLine("Sum of the first + second:");
            PrintPolynom(result);
            
            Console.WriteLine("First - second:");           
            result = SubstractPolynoms(firstPolynom, secondPolynom);
            PrintPolynom(result);

            Console.WriteLine("First * second:");
            result = MultiplyPolinoms(firstPolynom, secondPolynom);
            PrintPolynom(result);
        }

        
    }
}
