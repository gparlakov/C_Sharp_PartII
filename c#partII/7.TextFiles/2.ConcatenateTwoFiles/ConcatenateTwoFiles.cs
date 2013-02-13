//Write a program that concatenates two text files into another text file.

using System;
using System.IO;
using System.Text;

namespace NameConcatenateTwoFiles
{
    class ConcatenateTwoFiles
    {
        public static string ReadFile(string path,Encoding encoding)
        {
            string result;  
            StreamReader read = new StreamReader(path,encoding);
            using (read)
            {
                result = read.ReadToEnd();
            }
            return result;
        }

        public static void WriteFile(string path, string content)
        {
            StreamWriter write = new StreamWriter(path);
            using (write)
            {
                write.Write(content);
            }
        }
        
        static void Main()
        {
            StringBuilder filesContent = new StringBuilder();
            string path = @"..\..\..\textfiles\problem2\";
            string file1 = "test.txt";
            string file2 = "testCyrilic.txt";
            string fileFinal = "resultFile.txt";
            try
            {
                Encoding cyrylic = Encoding.GetEncoding(1251);
                filesContent.Append(ReadFile(path + file1, cyrylic));
                filesContent.Append(ReadFile(path + file2, cyrylic));
                WriteFile(path + fileFinal, filesContent.ToString());
                Console.WriteLine("Result is in {0}",path+fileFinal);
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
