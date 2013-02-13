//Write a program that reads a list of words from a file words.txt and finds 
//how many times each of the words is contained in another file test.txt. The 
//result should be written in the file result.txt and the words should be sorted by the number of their
//occurrences in descending order. Handle all possible exceptions in your methods.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NameCountWords
{
    class CountWords
    {//
        //Summary:
        //
        //After the program finishes it generates and old file (the original)
        //and replaces the original file
        //to repeat you must delete the replaced file and rename the 'old'
        // file back to the original name :) Simple - right;)
        static readonly string path = @"..\..\..\textfiles\problem13\";
        static readonly string file = "problem13.txt";
        static readonly string resultFile = "resultProblem13.txt";
        static readonly string dictionaryFile = "dictionary.txt";
        static readonly string[] separators = {" " , "," ,Environment.NewLine,"\t","\r\t"};

        
        //counts the words (as substring)
        //e.g. .word., word,somethingword adn so on
        static int WordCounter(string str, string word)
        {
            int counter = 0;
            int startIndex = 0;
            do
            {
                startIndex = str.IndexOf(word,startIndex);
                if (startIndex < 0)
                {
                    break;
                }
                counter++;
                startIndex+=word.Length;
            } while (true);

            return counter;
        }

        static void Main()
        {
            //string test = "test";

            //string row = @"<String ID=""testsysHealthSummary"">Retestsource test Overview</String>";
            //Console.WriteLine("{0}\n{1}\n", row, ClearWord(row, test));     

            //string row1 = @" test testtesttest  <?Copyright (c) Microsoft Corporation. All rights reserved.?>";
            //Console.WriteLine("{0}\n{1}\n",row1,ClearWord(row1, test));

            string row, dictionaryRow;
            string[] tempDictionary;
            Dictionary<string,int> dictionary = new Dictionary<string,int>();
            List<string> dict = new List<string>();
            try
            {
                //fills a dictionary with the words we are looking for
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
                            dictionary.Add(tempDictionary[i],0);
                            dict.Add(tempDictionary[i]);
                        }
                        //OrderBy key(the word) Descending
                        dictionary = dictionary.OrderByDescending(x => x.Key).ToDictionary(x=>x.Key,x=>x.Value);
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
                            
                            for (int i = 0; i < dict.Count; i++)
                            {		 
			                    dictionary[dict[i]] += WordCounter(row, dict[i]);
                            }
                            
                        }
                        //orderBy Value (count) descending 
                        dictionary = dictionary.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x=>x.Value);                        
                        foreach (var pair in dictionary)
                        {
                            writer.WriteLine("{1} {0}",pair.Key,pair.Value);
                        }
                    }
                }               
                Console.WriteLine("The result is written in {0}\nDescending by appearences first then by word", path + file);
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
            
        }
    }
}
