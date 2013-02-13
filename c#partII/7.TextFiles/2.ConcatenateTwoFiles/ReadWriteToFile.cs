using System;
using System.IO;

namespace NameConcatenateTwoFiles
{
    //
    //Summary:
    //
    //Reads and writes to a file three directories up and then one down:
    // ..\..\..\textfiles\<filename>  
    public class ReadWriteToFile
    {
        public static string Path = @"..\..\..\textfiles\";
        
        public static string ReadFile(string fileName)
        {
            string result;
            StreamReader read = new StreamReader(Path+fileName);
            using (read)
            {
                result = read.ReadToEnd();
            }
            return result;
        }

        public static void WriteFile(string fileName, string content)
        {
            StreamWriter write = new StreamWriter(Path+fileName);
            using (write)
            {
                write.Write(content);
            }
        }

    }
}
