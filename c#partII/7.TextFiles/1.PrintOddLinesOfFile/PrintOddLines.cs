//Write a program that reads a text file and prints on the console its odd lines.

using System;
using System.IO;

namespace NamePrintOddLinesOfFile
{
    class PrintOddLines
    {
        static void Main()
        {
            bool odd = false;
            try
            {
                StreamReader reader = new StreamReader(@"..\..\PrintOddLines.cs");
                using (reader)
                {
                    while (reader.ReadLine()!=null)
                    {                        
                        if (odd)
                        {
                            Console.WriteLine(reader.ReadLine());                            
                        }
                        odd = !odd;
                    }
                }
            }
            catch(IOException ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
