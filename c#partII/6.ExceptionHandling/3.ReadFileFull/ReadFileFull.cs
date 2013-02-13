//Write a program that enters file name along with its full file path 
//(e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console. 
//Find in MSDN how to use System.IO.File.ReadAllText(…). 
//Be sure to catch all possible exceptions and print user-friendly error messages.

using System;
using System.IO;
using System.Linq;

namespace NameReadFileFull
{
    class ReadFileFull
    {
        static void Main()
        {
            string path = Console.ReadLine(); //"test.txt";
                try
                {
                    Console.WriteLine(File.ReadAllText(path));
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Entered path shold not be empty,not-valid charachters or NULL!");
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (System.IO.IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch
                {
                    Console.WriteLine("An error occured but I don't know what to do :)");
                }
            //}

        }
    }
}
