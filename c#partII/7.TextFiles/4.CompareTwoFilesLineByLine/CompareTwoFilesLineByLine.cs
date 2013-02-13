//Write a program that compares two text files line by line and 
//prints the number of lines that are the same and the number 
//of lines that are different.Assume the files have equal number of lines.

using System;
using System.IO;
using System.Linq;

namespace NameCompareTwoFilesLineByLine
{
    class CompareTwoFilesLineByLine
    {
        static void Main()
        {
            string path = @"..\..\..\textfiles\problem4\";
            string file1 = "compareFile1.txt";
            string file2 = "compareFile2.txt";
            string rowFrom1, rowFrom2;
            int equalLines = 0, differentLines = 0;
            try
            {
                StreamReader reader1 = new StreamReader(path + file1);
                StreamReader reader2 = new StreamReader(path + file2);
                using (reader1)
                {
                    using (reader2)
                    {
                        do
                        {
                            rowFrom1 = reader1.ReadLine();
                            rowFrom2 = reader2.ReadLine();
                            if (rowFrom1 == rowFrom2)
                            {
                                equalLines++;
                            }
                            else
                            {
                                differentLines++;
                            }
                            //continues to check even after end of one of the files
                            //just in case
                        } while (rowFrom1 != null || rowFrom2 != null);
                    }
                }
                Console.WriteLine("Same lines count: {0}", equalLines);
                Console.WriteLine("Different lines count: {0}", differentLines);

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
