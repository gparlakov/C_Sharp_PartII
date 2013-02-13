//Write a program that reads a text file containing a list of strings, //sorts them and saves them to another text file. Example://    Ivan			    George//    Peter			    Ivan//    Maria			    Maria//    George			Peter

using System;
using System.Collections.Generic;
using System.IO;

namespace NameSortFileOfStringsIntoAnotherFile
{
    class SortFileOfStringsIntoAnotherFile
    {
        static string path = @"..\..\..\textfiles\problem6\";
        static string file = "unsorted.txt";
        static string resultFile = "Sorted.txt";
        
        static void Main()
        {
            string row;
            List<string> strings = new List<string>();

            try
            {
                StreamReader reader = new StreamReader(path + file);
                StreamWriter writer = new StreamWriter(path + resultFile);
                using (reader)
                {
                    using (writer)
                    {
                        while (true)
                        {
                            row = reader.ReadLine();
                            if (row==null)
                            {
                                break;
                            }
                            strings.Add(row);
                        }
                        strings.Sort();
                        for (int i = 0; i < strings.Count; i++)
                        {
                            writer.WriteLine(strings[i]);
                        }
                    }
                }
                Console.WriteLine("The result is written in {0}\nAnd the unsorted file is in {1}", path + resultFile, path + file);
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
