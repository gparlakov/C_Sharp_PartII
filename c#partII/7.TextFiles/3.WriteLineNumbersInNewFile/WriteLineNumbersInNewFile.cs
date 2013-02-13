using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NameConcatenateTwoFiles;
using System.IO;

namespace NameWriteLineNumbersInNewFile
{
    class WriteLineNumbersInNewFile
    {
        static void Main()
        {
            string path = @"..\..\..\textfiles\problem3\";
            string file = "test.txt";            
            string fileFinal = "resultProblem3.txt";
            int indexOfLine=0;
            string row = null;
            string numerator;

            try
            {
            StreamReader reader = new StreamReader(path+file);
            StreamWriter writer = new StreamWriter(path+fileFinal);            
                using (reader)
                {
                    using (writer)
                    {
                        row = reader.ReadLine();
                        do
                        {                            
                            numerator = indexOfLine + ". ";
                            writer.WriteLine(numerator + row);
                            indexOfLine++;
                            row = reader.ReadLine();
                        } while (row != null);
                    }
                }
                Console.WriteLine("The result is in {0}",path+fileFinal);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
  
        }
    }
}
