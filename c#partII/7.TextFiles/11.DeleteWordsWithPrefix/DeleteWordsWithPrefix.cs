//Write a program that deletes from a text file all 
//words that start with the prefix "test". Words
//contain only the symbols 0...9, a...z, A…Z, _.

using System;
using System.IO;
using System.Text;

namespace NameDeleteWordsWithPrefix
{
    class DeleteWordsWithPrefix
    {
        //
        //Summary:
        //
        //After the program finishes it generates and old file (the original)
        //and replaces the original file
        //to repeat you must delete the replaced file and rename the 'old'
        // file back to the original name :) Simple - right;)
        static readonly string path = @"..\..\..\textfiles\problem11\";
        static readonly string file = "problem11.txt";
        static readonly string resultFile = "resultProblem11.txt";               

        static bool IsInsideString(string str, int index)
        {
            if (index<0||index>str.Length-1)
            {
                return false;
            }
            return true;
        }

        static string ClearWord(string str, string startsWith)
        {
            StringBuilder result = new StringBuilder();
            int indexEnd = 0, indexStart = 0;
            char before, after;

            do
            {
                if (indexStart < 0)
                {
                    break;
                }
                indexEnd = str.IndexOf(startsWith, indexStart);
                if (indexEnd < 0)
                {
                    result.Append(str, indexStart, str.Length - indexStart);
                    break;
                }
                result.Append(str, indexStart, indexEnd - indexStart);

                //if before is inside the string take the symbol before it -
                //if not assume empty space - so word starts with "startsWith"
                if (IsInsideString(str, indexEnd - 1))
                {
                    before = str[indexEnd - 1];
                }
                else
                {
                    before = ' ';
                }

                //if end of word after is outside of string assume word ends there
                // if not take the symbol after
                if (IsInsideString(str, indexEnd + startsWith.Length))
                {
                    after = str[indexEnd + startsWith.Length];
                }
                else
                {
                    after = ' ';
                }
                
                if (!(char.IsPunctuation(before) || before == ' ' || before == '_')) 
                {                  
                    result.Append(startsWith);
                    indexStart = indexEnd + startsWith.Length;
                }
                else
                {
                    //put the indexStart At the end of the word 'startsWith' 
                    //and count how long is the word after it
                    //so the next search for the word will start after the 
                    //end of the current word and it will be left out of the new string                    
                    indexStart = indexEnd + startsWith.Length - 1;
                    do
                    {
                        indexStart++;
                        if (IsInsideString(str,indexStart))
                        {
                            after = str[indexStart];
                        }
                        else
                        {
                            after = ' ';
                        }
                        
                    }while (char.IsLetterOrDigit(after) || after == '_');                   
                }

                
            } while (indexEnd >= 0);

            return result.ToString();
        }

        static void Main()
        {
            //string test = "test";
            
            //string row = @"<String ID=""testsysHealthSummary"">Retestsource test Overview</String>";
            //Console.WriteLine("{0}\n{1}\n", row, ClearWord(row, test));     
      
            //string row1 = @" test testtesttest  <?Copyright (c) Microsoft Corporation. All rights reserved.?>";
            //Console.WriteLine("{0}\n{1}\n",row1,ClearWord(row1, test));

            string row;
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
                            row = ClearWord(row, "test");
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
            catch (IOException ioExcept)
            {
                Console.WriteLine("{0}File is either {1} or {2} or {3} \nin directory {4}", ioExcept.Message, file, "old" + file, resultFile, path);
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


