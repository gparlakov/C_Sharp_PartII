//A dictionary is stored as a sequence of text lines containing words and their 
//explanations. Write a program that enters a word and translates it by using the 
//dictionary. Sample dictionary:
//.NET – platform for applications from Microsoft//CLR – managed execution environment for .NET//namespace – hierarchical organization of classes

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Dictionary
{
    class Dictionary
    {
        static void Main()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add(".NET", "platform for applications from Microsoft");
            dict.Add("CLR", "managed execution environment for .NET");
            dict.Add("namespace", "hierarchical organization of classes");
            dict.Add("string" ,"equals String class, readonly array of chars");
            dict.Add("char", "a symbol represented by its value taken from ascii,utf-8,utf-16,windows-1251 or some other table");
            dict.Add("int", "equals Int32 class");

            Console.WriteLine("Dictionary contains definitions of the writtne below words:");
            foreach (var def in dict)
            {
                Console.WriteLine(def.Key);
            }
            Console.WriteLine("Which do you want?");
            try
            {
                do
                {
                    Console.WriteLine(dict[Console.ReadLine()]);
                    Console.WriteLine("next:"); 
                } while (true);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("no such definition");
            }
        }

    }
}
