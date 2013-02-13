//Write a program that extracts from given XML file all the text without the tags.
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameDeleteWordsWithPrefix
{
    class ClearTagsFromXML
    {
        //
        //Summary:
        //
        //After the program finishes it generates and old file (the original)
        //and replaces the original file
        //to repeat you must delete the replaced file and rename the 'old'
        // file back to the original name :) Simple - right;)
        static readonly string path = @"..\..\..\textfiles\problem10\";
        static readonly string file = "test3.xml";
        static readonly string resultFile = "resultProblem10.xml";

        static string ClearTags(string str)
        {
            StringBuilder result = new StringBuilder();
            int indexEnd = 0, indexStart = 0;
            //char before, after;

            do
            {
                indexStart = str.IndexOf('>', indexStart);
                if (indexStart < 0)
                {
                    break;
                } 
                indexEnd = str.IndexOf('<', indexStart);
                if (indexEnd < 0)
                {                    
                    break;
                }     
                result.Append(str, indexStart+1, indexEnd - indexStart-1);
                indexStart++;                
            } while (indexEnd >= 0);

            return result.ToString();
        }
        static void Main()
        {
            //string row = @"<String ID=""sysHealthSummary"">Resource Overview</String>";
            //row = ClearTags(row);
            //Console.WriteLine(row);
            //string row1 = @"<?Copyright (c) Microsoft Corporation. All rights reserved.?>";
            //row1 = ClearTags(row1);
            //Console.WriteLine(row1);
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
                            row = ClearTags(row);
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
                Console.WriteLine("{0}File is either {1} or {2} or {3} \nin directory {4}" ,ioExcept.Message,file,"old"+file,resultFile,path);                
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

