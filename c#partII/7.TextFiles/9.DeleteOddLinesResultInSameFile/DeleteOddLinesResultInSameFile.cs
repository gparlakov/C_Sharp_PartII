//Write a program that deletes from given text file all odd lines. The result should be in the same file.

using System;
using System.IO;

namespace NameReplaceWordNotSubstring
{
    class ReplaceWordNotSubstring
    {
        //
        //Summary:
        //
        //After the program finishes it generates and old file (the original)
        //and replaces the original file
        //to repeat you must delete the replaced file and rename the 'old'
        // file back to the original name :) Simple - right;)
        static readonly string path = @"..\..\..\textfiles\problem9\";
        static readonly string file = "Problem9.txt";
        static readonly string resultFile = "resultProblem9.txt";

        static void Main()
        {           
            string row;
            bool indexer = false;
            try
            {
                StreamReader reader = new StreamReader(path + file);
                StreamWriter writer = new StreamWriter(path + resultFile);
                int index = 0;
                using (reader)
                {
                    using (writer)
                    {
                        while (true)
                        {
                            row = reader.ReadLine();
                            if (row == null)
                            {
                                break;
                            }
                            if (indexer)
                            {
                                writer.WriteLine(row);
                            }
                            indexer = !indexer;
                        }
                    }
                }

                //move/rename the old file 
                //and rename the result to the same file ;)                
                File.Move(path + file, path + "old" + file);
                File.Move(path + resultFile, path + file);
                Console.WriteLine("The result is written in {0}\nAnd the backup of te original file is in {1}", path + file, path + "old" + file);
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
                Console.WriteLine("{2}File is either {0}, {1} or {3}", file, resultFile, ioExcept.Message, "old" + file);               
            }
            finally
            {
                //if exception is hit - clear the temporary file
                if (File.Exists(path + resultFile))
                {
                    File.Delete(path + resultFile);
                }
            }
        }
    }

}
