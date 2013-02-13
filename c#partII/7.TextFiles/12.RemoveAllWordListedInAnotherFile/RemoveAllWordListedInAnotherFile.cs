//Write a program that removes from a text file all words listed in 
//given another text file. Handle all possible exceptions in your methods.

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using NameReplaceWordNotSubstring;


namespace NameRemoveAllWordListedInAnotherFile
{
    class RemoveAllWordListedInAnotherFile
    {
        ///
        ///Summary:
        ///
        ///After the program finishes it generates and old file (the original)
        ///and replaces the original file
        ///to repeat you must delete the replaced file and rename the 'old'
        /// file back to the original name :) Simple - right;)
        static readonly string path = @"..\..\..\textfiles\problem12\";
        static readonly string file = "problem12.txt";
        static readonly string resultFile = "resultProblem12.txt";
        static readonly string dictionaryFile = "dictionary.txt";
        static readonly string[] separators = {" " , "," ,Environment.NewLine,"\t","\r\t"}; 

        static void Main()
        {
            //string test = "test";

            //string row = @"<String ID=""testsysHealthSummary"">Retestsource test Overview</String>";
            //Console.WriteLine("{0}\n{1}\n", row, ClearWord(row, test));     

            //string row1 = @" test testtesttest  <?Copyright (c) Microsoft Corporation. All rights reserved.?>";
            //Console.WriteLine("{0}\n{1}\n",row1,ClearWord(row1, test));

            string row,dictionaryRow,tempRow;
            string[] tempDictionary;
            List<string> dictionary = new List<string>();


            try
            {
                ///fills a dictionary with the words we are looking for 
                StreamReader dictionaryReader = new StreamReader(path + dictionaryFile);
                using (dictionaryReader)
                {
                    do
                    {
                        dictionaryRow = dictionaryReader.ReadLine();
                        if (dictionaryRow == null)
                        {
                            break;
                        }
                        tempDictionary = dictionaryRow.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < tempDictionary.Length; i++)
                        {
                            dictionary.Add(tempDictionary[i]);
                        }

                    } while (true);
                }
                StreamReader reader = new StreamReader(path + file);
                StreamWriter writer = new StreamWriter(path + resultFile);
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

                            //because on the first run some words 
                            tempRow = row;
                            do
                            {
                                row = tempRow;
                                for (int i = 0; i < dictionary.Count; i++)
                                {
                                    tempRow = ReplaceWordNotSubstring.ReplaceWord(tempRow, dictionary[i], null);
                                }

                            } while (tempRow != row);


                            if (!String.IsNullOrEmpty(row))
                            {
                                writer.WriteLine(row);
                            }
                        }
                    }
                }

                //move/rename the old file 
                //and rename the result to the same file ;)                
                File.Move(path + file, path + "old" + file);
                File.Move(path + resultFile, path + file);
                Console.WriteLine("The result is written in {0}\nAnd the first file is in {1}", path + file, path + "old" + file);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Argument is null!");
            }
            catch (ArgumentException argumEx)
            {
                Console.WriteLine(argumEx.Message);
            }
            catch (FileNotFoundException notFoundEx)
            {
                Console.WriteLine(notFoundEx.Message);
            }
            catch (IOException ioExcept)
            {
                Console.WriteLine("{0}File is either check {1} or {2} or {3} \nin directory {4}", ioExcept.Message, file, "old" + file, resultFile, path);
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
