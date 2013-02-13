//You are given a text. Write a program that changes the text in all regions surrounded by the tags //<upcase> and </upcase> to uppercase. The tags cannot be nested. Example://We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.//        The expected result://We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.UppercaseTags
{
    class Program
    {
        static void Main()
        {
            string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else. We are We a<upcase>to do</upcase>re living in a <upcase>to do</upcase>. We don't have <upcase>anything</upcase> else.living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
            text = Upcase(text);
            Console.WriteLine(text);
        }

        private static string Upcase(string text)
        {
            int startIndex = 0, endIndex = 0;
            StringBuilder uppercased = new StringBuilder();
            do
            {
                endIndex = text.IndexOf("<upcase>", startIndex);
                if (endIndex < 0)
                {
                    uppercased.Append(text, startIndex, text.Length-startIndex);
                    break;
                }
                uppercased.Append(text, startIndex, endIndex - startIndex);
                startIndex = endIndex;

                endIndex = text.IndexOf("</upcase>", startIndex);
                string temp = text.Substring(startIndex + 8, endIndex - startIndex-8);

                temp=temp.ToUpper();
                uppercased.Append(temp);
                startIndex = endIndex+9;

            } while (startIndex > 0);
            return uppercased.ToString();
        }
    }
}
