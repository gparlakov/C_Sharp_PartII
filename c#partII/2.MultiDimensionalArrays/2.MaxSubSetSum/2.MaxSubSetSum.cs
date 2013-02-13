//Write a program that reads a rectangular matrix of size N x M 
//and finds in it the square 3 x 3 that has maximal sum of its elements.

using System;

    class MaxSubSetSum
    {
        static void Main()
        {
            Console.WriteLine("how big is the matrix");
            int n=0,m=0;
            do
            {
                Console.WriteLine("n=?");
            } while (!int.TryParse(Console.ReadLine(), out n));
            do
            {
                Console.WriteLine("m=?");
            } while (!int.TryParse(Console.ReadLine(), out m));

            int[,] numbers = new int[n, m];/*{{1, 2, 3, 6, 7, 9, 1, 2, 3, 6, 7, 9  },
                                              {2, 3, 4, 5, 4, 3, 4, 5, 6, 3, 1, 2  },
                                              {4, 5, 6, 3, 1, 20, 2, 3, 4, 5, 4, 3 },
                                              {2, 3, 4, 5, 14, 3, 40, 5, 6, 3, 1, 2} };// new int[n, m];*/

            int matrixSize = 3, currentSum = 0, maxSum = int.MinValue, rowStart = -1, colStart = -1;

            for (int i = 0; i < n; i++)
            {
                for (int y = 0; y < m; y++)
                {
                     Console.Write("[{0},{1}] = ",i,y);
                     numbers[i,y]=int.Parse(Console.ReadLine());  
                }
            }

            for (int row = 0; row <= numbers.GetLength(0) - matrixSize; row++)
            {
                for (int col = 0; col <= numbers.GetLength(1) - matrixSize; col++)
                {
                    currentSum = 0;
                    for (int matrixRow = row; matrixRow < matrixSize+row; matrixRow++)
                    {
                        for (int matrixCol = col; matrixCol < matrixSize+col; matrixCol++)
                        {
                            currentSum += numbers[matrixRow, matrixCol];
                        }
                    }
                    if (currentSum>maxSum)
                    {
                        maxSum = currentSum;
                        rowStart = row;
                        colStart = col;
                    }
                }
            }

            Console.WriteLine(maxSum);
            for (int i = rowStart; i < matrixSize+rowStart; i++)
            {
                for (int y = colStart; y < matrixSize+colStart; y++)
                {
                    Console.Write(numbers[i,y] + " ");
                }
                Console.WriteLine();
            }
        }
    }
