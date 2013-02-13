using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NameBombingCuboid
{
    class BombingCuboid
    {
        static char[, ,] cuboid;
        static int[] destroyed = new int['Z'+1];
        static int width, heigth, depth,numberBobs;
        static string[] separators = { " " };
        //static StreamReader reader;
        static List<int[]> bombs = new List<int[]>() ;
        static int counter = 0;
        
        static void Main(string[] args)
        {
            //reader = new StreamReader("test.txt");
            
            //using (reader)
            //{
                string[] cubeMetrics = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                width = int.Parse(cubeMetrics[0]);
                heigth = int.Parse(cubeMetrics[1]);
                depth = int.Parse(cubeMetrics[2]);
                cuboid = new char[width, heigth, depth];
                InputCube(width, heigth, depth);

                //OutputCube();

                numberBobs=int.Parse(Console.ReadLine());                
                InputBombs(numberBobs);
                for (int i = 0; i < numberBobs; i++)
                {
                    DetonateBomb(bombs[i]);
                    //Console.WriteLine();
                    //OutputCube();
                    //
                }
                Console.WriteLine(counter);
                for (int j = 0; j < destroyed.Length; j++)
                {
                    if (destroyed[j] != 0)
                    {
                        Console.WriteLine("{0} {1}", (char)j, destroyed[j]);
                    }
                }

            //}
        }

        private static void DetonateBomb(int[] bombWHDPow)
        {
            int bombWidth = bombWHDPow[0],
                bombHeigth = bombWHDPow[1],
                bombDepth= bombWHDPow[2],
                bombPower=bombWHDPow[3];


            for (int currHeigth = bombHeigth - bombPower; currHeigth <= bombHeigth + bombPower; currHeigth++)
            {
                if (IsInsideCube(currHeigth,heigth))
                {
                    for (int currDepth = bombDepth - bombPower; currDepth <= bombDepth + bombPower; currDepth++)
                    {
                        if (IsInsideCube(currDepth,depth))
                        {
                            for (int currWidth = bombWidth-bombPower; currWidth <= bombWidth+bombPower; currWidth++)
                            {
                                if (IsInsideCube(currWidth,width))
                                {
                                    double distance = Math.Sqrt(Math.Pow(currWidth-bombWidth,2)+Math.Pow(currHeigth-bombHeigth,2)+Math.Pow(currDepth-bombDepth,2));
                                    if (distance<=bombPower)
                                    {
                                        Destroy(currWidth, currHeigth, currDepth);                                        
                                    }
                                }
                            }
                        }   
                    }
                }
            }

           SeeWhatFalls(bombWidth,bombHeigth,bombDepth,bombPower);
        }

        private static void SeeWhatFalls(int bombWidth, int bombHeigth, int bombDepth, int bombPower)
        {            
                for (int currDepth = bombDepth - bombPower; currDepth <= bombDepth + bombPower; currDepth++)
                {
                    if (IsInsideCube(currDepth, depth))
                    {
                        for (int currWidth = bombWidth - bombPower; currWidth <= bombWidth + bombPower; currWidth++)
                        {
                            if (IsInsideCube(currWidth, width))
                            {
                                int startingHeight = bombHeigth - bombPower > 0 ? bombHeigth - bombPower : 0;
                                //, moveToHeight = 0;
                                //check if empty
                                //find full
                                //move full to empty
                                //delete full

                                for (int searchingHigth = startingHeight; searchingHigth < heigth; searchingHigth++)
                                {
                                    if (cuboid[currWidth, searchingHigth, currDepth] == '0')
                                    {
                                        for (int moveFromHeight = searchingHigth + 1; moveFromHeight < heigth; moveFromHeight++)
                                        {
                                            if (cuboid[currWidth,moveFromHeight,currDepth]!='0')
                                            {
                                                cuboid[currWidth, searchingHigth, currDepth] = cuboid[currWidth, moveFromHeight, currDepth];
                                                cuboid[currWidth, moveFromHeight, currDepth] = '0';
                                                break;
                                                
                                            }
                                        }
                                    }
                                }


                            }
                        }
                    }
                }            
        }

        private static void Destroy(int currWidth, int currHeigth, int currDepth)
        {
            if (cuboid[currWidth,currHeigth,currDepth]!='0')
            {
                destroyed[(int)cuboid[currWidth, currHeigth, currDepth]]++;
                cuboid[currWidth, currHeigth, currDepth] = '0';
                counter++;
            }            
        }

        static bool IsInsideCube(int index, int maximum)
        {
            if (index >= 0 && index < maximum)
            {
                return true;
            }
            return false;
        }

        private static void InputBombs(int numberBobs)
        {
            string[] separated;    
            for (int i = 0; i < numberBobs; i++)
            {
                separated = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                bombs.Add(new int[4]);
                for (int j = 0; j < 4; j++)
                {
                    bombs[i][j] = int.Parse(separated[j]);
                }
            }
        }

        private static void OutputCube()
        {
            for (int currHeigth = 0; currHeigth < heigth; currHeigth++)
            {                
                for (int currDepth = 0; currDepth < depth; currDepth++)
                {                    
                    for (int currWidth = 0; currWidth < width; currWidth++)
                    {
                        Console.Write(cuboid[currWidth, currHeigth, currDepth]) ;
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            } 
        }

        private static void InputCube(int width, int heigth, int depth)
        {
            for (int currHeigth = 0; currHeigth < heigth; currHeigth++)
            {
                string[] rows = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                for (int currDepth = 0; currDepth < depth; currDepth++)
                {
                    string row = rows[currDepth];
                    for (int currWidth = 0; currWidth < width; currWidth++)
                    {
                        cuboid[currWidth, currHeigth, currDepth] = row[currWidth];
                    }
                }
            }
        }
    }
}
