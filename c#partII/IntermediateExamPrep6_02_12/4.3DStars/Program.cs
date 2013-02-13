using System;
using System.IO;

namespace _4.Stars3DD
{
    class Program
    {
        static string[] separators = new string[] { " " };
        static char[, ,] cube;//= new char[width, heigth, depth];
        static char[] starsWithLetters = new char['Z' + 1];
        static int starCounter = 0;

        static char[, ,] InputCube(char[, ,] cube, int width, int heigth, int depth)
        {
            for (int currHeigth = 0; currHeigth < heigth; currHeigth++)
            {
                string[] rows = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                for (int currDepth = 0; currDepth < depth; currDepth++)
                {
                    string row = rows[currDepth];
                    for (int currWidth = 0; currWidth < width; currWidth++)
                    {
                        cube[currWidth, currHeigth, currDepth] = row[currWidth];
                    }
                }
            }
            return cube;
        }

        private static void OutputCube(int width, int heigth, int depth)
        {
            for (int currHeigth = 0; currHeigth < heigth; currHeigth++)
            {
                for (int currDepth = 0; currDepth < depth; currDepth++)
                {
                    for (int currWidth = 0; currWidth < width; currWidth++)
                    {
                        Console.Write(cube[currWidth, currHeigth, currDepth]);
                    }
                    Console.Write(' ');
                } Console.WriteLine();
            }

        }

        private static void CountStars(char[, ,] cube, int width, int heigth, int depth)
        {
            for (int currWidth = 1; currWidth < width - 1; currWidth++)
            {
                for (int currHeigth = 1; currHeigth < heigth - 1; currHeigth++)
                {
                    for (int currDepth = 1; currDepth < depth - 1; currDepth++)
                    {
                        if (IsStar(cube, currWidth, currHeigth, currDepth))
                        {
                            starsWithLetters[(int)cube[currWidth, currHeigth, currDepth]]++;
                            starCounter++;
                        }
                    }
                }
            }
        }

        static bool IsStar(char[, ,] cube, int currWidth, int currHeigth, int currDepth)
        {
            bool star = true;
            char center = cube[currWidth, currHeigth, currDepth];
            if (cube[currWidth, currHeigth - 1, currDepth] != center)
            {
                return false;
            }
            if (cube[currWidth, currHeigth + 1, currDepth] != center)
            {
                return false;
            }
            if (cube[currWidth - 1, currHeigth, currDepth] != center)
            {
                return false;
            }
            if (cube[currWidth + 1, currHeigth, currDepth] != center)
            {
                return false;
            }
            if (cube[currWidth, currHeigth, currDepth - 1] != center)
            {
                return false;
            }
            if (cube[currWidth, currHeigth, currDepth + 1] != center)
            {
                return false;
            }
            return star;
        }

        static void Main()
        {
            int width;
            int heigth;
            int depth;
            string[] input = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            width = int.Parse(input[0]);
            heigth = int.Parse(input[1]);
            depth = int.Parse(input[2]);
            cube = new char[width, heigth, depth];

            cube = InputCube(cube, width, heigth, depth);
            //  OutputCube(width, heigth, depth);
            CountStars(cube, width, heigth, depth);
            Console.WriteLine(starCounter);
            for (int i = 0; i < starsWithLetters.Length; i++)
            {
                if (starsWithLetters[i] != 0)
                {
                    Console.WriteLine("{0} {1}", (char)i, (int)starsWithLetters[i]);
                }
            }
        }
    }
}