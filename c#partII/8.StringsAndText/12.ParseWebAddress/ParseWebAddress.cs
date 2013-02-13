//Write a program that parses an URL address given in the format://        and extracts from it the [protocol], [server] and [resource] elements. For example from the URL//        http://www.devbg.org/forum/index.php the following information should be extracted://        [protocol] = "http"//        [server] = "www.devbg.org"//        [resource] = "/forum/index.php"

using System;

namespace _12.ParseWebAddress
{
    class ParseWebAddress
    {
        static void Main(string[] args)
        {
            try
            {
                string webAddr, protocol, server, resourse;
                // webAddr = "http://mail.abv.bg/mail/server/archive";
                Console.WriteLine("Address?:");
                webAddr = Console.ReadLine();
                protocol = webAddr.Substring(0, webAddr.IndexOf("://"));
                resourse = webAddr.Substring(webAddr.IndexOf('/', protocol.Length + 3));
                webAddr = webAddr.Remove(0, protocol.Length + 3);
                webAddr = webAddr.Remove(webAddr.Length - resourse.Length);
                server = webAddr;
                Console.WriteLine("{0}\n{1}\n{2}", protocol, server, resourse);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("There's something missing from the addres");
            }
            
        }
    }
}
