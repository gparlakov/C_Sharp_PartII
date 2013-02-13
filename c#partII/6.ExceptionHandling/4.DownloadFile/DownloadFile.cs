//Write a program that downloads a file from Internet 
//(e.g. http://www.devbg.org/img/Logo-BASD.jpg) and stores it the current directory. 
//Find in Google how to download files in C#. Be sure to catch all exceptions and to
//free any used resources in the finally block.

using System;
using System.Linq;
using System.IO;
using System.Net;

namespace NameDownloadFile
{
    class DownloadFile
    {
        static void Main()
        {
            WebClient downloader = new WebClient();
            try
            {
                using (downloader)
                {
                    downloader.DownloadFile("http://www.textfiles.com/100/914bbs.txt", "downloaded.txt");
                    Console.WriteLine(File.ReadAllText("downloaded.txt"));
                }

            }
            catch (ArgumentException)
            {
                Console.WriteLine("Path to file sholud not be empty or contain not-path charachters!");
            }            
            catch (WebException excWeb)
            {
                Console.WriteLine(excWeb.Message);
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("This Method is being called by someone else.\nWait and try again");
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
                
        }
    }
}
