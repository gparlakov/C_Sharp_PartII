//Write a program that reads a text file containing a //square matrix of numbers and finds in the matrix an //area of size 2 x 2 with a maximal sum of its elements. //The first line in the input file contains the size of matrix//N. Each of the next N lines contain N numbers separated by space. //The output should be a single number in a separate text file. Example://4//2 3 3 4//0 2 3 4			17//3 7 1 2//4 3 3 2

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;


namespace NameFindMaxInMatrix
{
    class FindMaxInMatrix
    {
        static string path = @"..\..\..\textfiles\problem5\";
        static string file = "matrix.txt";
        static string resultFile = "resultProblem5.txt";

        static void FindMaxSum(List<List<int>> numbers, int sumLength)
        {
            int maxSum = int.MinValue;
            int nextSum = 0;
            int maxStartRow = 0, maxStartCol = 0;
            for (int row = 0; row <= numbers.Count-sumLength; row++)
            {
                for (int col = 0; col <= numbers[row].Count-sumLength; col++)
                {
                    for (int rowSum = row; rowSum < row+sumLength; rowSum++)
                    {
                        for (int colSum = col; colSum < col+sumLength; colSum++)
                        {
                            nextSum += numbers[rowSum][colSum];
                        }
                    }
                    if (nextSum>maxSum)
                    {
                        maxSum = nextSum;
                        maxStartRow = row;
                        maxStartCol = col;
                    }
                    nextSum = 0;
                }
            }
            StreamWriter writer = new StreamWriter(path + resultFile);
            using (writer)
            {
                writer.WriteLine("maximum sum of length {1} is {0}", maxSum, sumLength);
                for (int i = maxStartRow; i < maxStartRow + sumLength; i++)
                {
                    for (int y = maxStartCol; y < maxStartCol + sumLength; y++)
                    {
                        writer.Write(numbers[i][y] + " ");
                    }
                    writer.WriteLine();
                }
            }
            Console.WriteLine("The result is written in {0}\nAnd the matrix file is in {1}", path + resultFile, path + file);
        }
        
        static List<int> parseLine(string row)
        {
            List<int> nextRow = new List<int>();
            string[] numbers = row.Split(' ');
            for (int i = 0; i < numbers.Length; i++)
            {
                nextRow.Add(int.Parse(numbers[i]));
            }
            return nextRow;
        }

        
        static void Main()
        {            
            string row;
            string[] splitt = new string[1];
            
            List<List<int>> matrix = new List<List<int>>();

            try
            {
                StreamReader reader = new StreamReader(path + file);
                StreamWriter writer = new StreamWriter(path + resultFile);
                using (reader)
                {
                    using (writer)
                    {
                        row = reader.ReadLine();
                        do
                        {
                            splitt = row.Split(' ');

                            //skip over the first line
                            if (splitt.Length != 1)
                            {
                                matrix.Add(parseLine(row));
                            }
                            row = reader.ReadLine();
                        } while (row != null);
                    }
                }
                FindMaxSum(matrix, 3);


            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Argument is null!");
            }
            catch (ArgumentException argumEx)
            {
                Console.WriteLine(argumEx.Message);
            }
            catch (IOException ioExcept)
            {
                Console.WriteLine(ioExcept.Message, ioExcept.StackTrace);
            }
        }
    }
}
