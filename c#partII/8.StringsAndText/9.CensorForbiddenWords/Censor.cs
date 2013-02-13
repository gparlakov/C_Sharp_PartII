using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameCensorForbiddenWords
{
    public class Censor
    {
        
            //
            //Summary:        
            //      After the program finishes it generates and old file (the original)
            //      and replaces the original file
            //      to repeat you must delete the replaced file and rename the 'old'
            //      file back to the original name :) Simple - right;)
            //      Programm works fine just give it a few seconds
            
            //static readonly string path = @"..\..\..\textfiles\problem8\";
            //static readonly string file = "Problem8.txt";
            //static readonly string resultFile = "resultProblem8.txt";

            static char IfInsideReturnSymbol(string str, int index)
            {
                char symbol;
                if (index < 0 || index > str.Length - 1)
                {
                    symbol = ' ';
                }
                else
                {
                    symbol = str[index];
                }
                return symbol;
            }


            ///
            ///Summary:                
            ///      Removes words from target string but leaves substrings untouched
            ///
            /// Returns:
            ///     String with removed words
            ///
            /// Exceptions:
            ///   System.OutOfMemoryException:
            ///     There is insufficient memory to allocate a buffer for the returned string.        
            public static string CensorWord(string strNormal, string word, string replacementWord)
            {
                string strLowerCased = strNormal.ToLower();
                string wordLowerCased = word.ToLower();
                StringBuilder result = new StringBuilder();
                int indexEnd = 0, indexStart = 0;
                char before, after;

                do
                {
                    indexEnd = strLowerCased.IndexOf(wordLowerCased, indexStart);
                    if (indexEnd < 0)
                    {
                        result.Append(strNormal, indexStart, strNormal.Length - indexStart);
                        break;
                    }
                    result.Append(strNormal, indexStart, indexEnd - indexStart);
                    before = IfInsideReturnSymbol(strNormal, indexEnd - 1);
                    after = IfInsideReturnSymbol(strNormal, indexEnd + word.Length);

                    //Summary:
                    //      Checks whether the word is alone or part of another word
                    //      if its surrounded with anything else but letters,numbers or _
                    //      I asuume it's alone e.g "word", "word, <word>  word ,word,
                    //      not alone (and not replaced) word- word_free word_ 9word word56 words and so on
                    if (char.IsLetterOrDigit(before) || before == '_' || char.IsLetterOrDigit(after) || after == '_')
                    {
                        result.Append(word);
                    }
                    else
                    {
                        result.Append(replacementWord);
                    }
                    indexStart = indexEnd + word.Length;
                } while (indexEnd >= 0);

                return result.ToString();
            }

            //static void Main()
            //{
            //    //string row = "This is a start!String and has a start and a finish. This is another startString and has a (Start)! (start) start,end and a finish.";
            //    //row = ReplaceWord(row, "start", "end");
            //    //Console.WriteLine(row);
            //    //string row1 = "This is a String and has a and a finish. This is another tString and has a end and a finish.";
            //    //row1 = ReplaceWord(row1, "start", "end");
            //    //Console.WriteLine(row1);
            //    string row;
            //    try
            //    {
            //        Console.WriteLine("Programm works fine just give it a few seconds ;)");
            //        StreamReader reader = new StreamReader(path + file);
            //        StreamWriter writer = new StreamWriter(path + resultFile);
            //        using (reader)
            //        {
            //            using (writer)
            //            {
            //                while (true)
            //                {
            //                    row = reader.ReadLine();
            //                    if (row == null)
            //                    {
            //                        break;
            //                    }
            //                    row = ReplaceWord(row, "start", "end");
            //                    writer.WriteLine(row);
            //                }
            //            }
            //        }

            //        //move/rename the old file 
            //        //and rename the result to the same file ;)                
            //        File.Move(path + file, path + "old" + file);
            //        File.Move(path + resultFile, path + file);
            //        Console.WriteLine("The result is written in {0}\nAnd the first file is in {1}", path + file, path + "old" + file);
            //    }
            //    catch (ArgumentNullException)
            //    {
            //        Console.WriteLine("Argument is null!");
            //    }
            //    catch (ArgumentException argumEx)
            //    {
            //        Console.WriteLine(argumEx.Message);
            //    }
            //    catch (IOException ioExcept)
            //    {
            //        Console.WriteLine("{2}File is either {0}, {1} or {3}", file, resultFile, ioExcept.Message, "old" + file);
            //    }
            //    finally
            //    {
            //        //if exception is hit - clear the temporary file
            //        if (File.Exists(path + resultFile))
            //        {
            //            File.Delete(path + resultFile);
            //        }
            //    }
            //}
        }
    
}
