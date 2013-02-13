//Write a program that replaces all occurrences of the substring 
//"start" with the substring "finish" in a text file.
//Ensure it will work with large files (e.g. 100 MB).

using System;
using System.IO;
using System.Linq;
using System.Text;


namespace NameReplaceSubStringInFile
{
    class ReplaceSubStringInFile
    {
        static readonly string path = @"..\..\..\textfiles\problem7\";
        static readonly string file = "Problem7.txt";
        static readonly string resultFile = "resultProblem7.txt";

        
        
        static string ReplaceWord(string str, string word,string replacemetWord)
        {
            StringBuilder result = new StringBuilder();
            int indexEnd = 0,indexStart=0;
            char before, after;
            
            do
            {
                indexEnd = str.IndexOf(word, indexStart);
                if (indexEnd<0)
                {
                    result.Append(str, indexStart, str.Length - indexStart);
                    break;
                }
                result.Append(str, indexStart,indexEnd-indexStart );
                before = str[indexEnd - 1];
                after = str[indexEnd+word.Length];
                if (char.IsPunctuation(before) || before==' ' && char.IsPunctuation(before) || after==' ') 
                {
                    result.Append(replacemetWord);
                }
                else
                {
                    result.Append(word);
                }
                indexStart = indexEnd + word.Length;                
            } while (indexEnd>=0);
            
            return result.ToString();
        }
        static void Main()
        {
            //string row = "This is a startString and has a start and a finish. This is another startString and has a (Start)! (start) start,end and a finish.";
            //row = ReplaceWord(row, "start","end");
            //Console.WriteLine(row);
            //string row1 = "This is a String and has a and a finish. This is another tString and has a end and a finish.";
            //row1 = ReplaceWord(row1, "start", "end");
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
                            if (row == null)
                            {
                                break;
                            }
                            row = row.Replace("start", "end");                            
                            writer.WriteLine(row);
                        }
                    }
                }
                                                
                //move/rename the old file 
                //and rename the result to the same file ;)
                File.Move(path + file, path + "old" + file);
                File.Move(path + resultFile, path + file);
                Console.WriteLine("The result is written in {0}\nAnd the first file is in {1}",path+file,path+"old"+file);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Argument is null!");
            }
            catch (ArgumentException argumEx)
            {
                Console.WriteLine(argumEx.Message,argumEx.Source);                
            }
            catch (IOException ioExcept)
            {
                Console.WriteLine("{2}File is either {0}, {1} or {3}",file,resultFile,ioExcept.Message,"old"+file);                
            }
        }
    }
}
