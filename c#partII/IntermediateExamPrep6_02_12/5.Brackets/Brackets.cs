using System;
using System.Linq;
using System.Numerics;

namespace NameBrackets
{
    class Brackets
    { 
        static char[] brackets = new char[2] { '(', ')' };

        static void Main()
        {
            string sequence = Console.ReadLine();

            int length = sequence.Length;
            BigInteger[,] possibleCombinations = new BigInteger[length + 2, length + 2];
            possibleCombinations[0, 0] = 1;

            for (int row = 1; row <= length; row++)
            {
                for (int col = 1; col <= length; col++)
                {
                    if (sequence[row - 1] == '?')
                    {
                        possibleCombinations[row, 0] = possibleCombinations[row - 1, 1];
                        possibleCombinations[row, col] = possibleCombinations[row - 1, col - 1] + possibleCombinations[row - 1, col + 1];
                    }
                    else if (sequence[row - 1] == '(')
                    {
                        possibleCombinations[row, col] = possibleCombinations[row - 1, col - 1];

                    }
                    else
                    {
                        possibleCombinations[row, 0] = possibleCombinations[row - 1, 1];
                        possibleCombinations[row, col] = possibleCombinations[row - 1, col + 1];
                    }
                }
            }
            Console.WriteLine(possibleCombinations[sequence.Length, 0]);
        }

    }
}
