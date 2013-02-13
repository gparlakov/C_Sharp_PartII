//Write a program that extracts from given HTML file its title 
//(if available), and its body text without the HTML tags. Example:
//<html>
//  <head><title>News</title></head>
//  <body><p><a href="http://academy.telerik.com">Telerik
//    Academy</a>aims to provide free real-world practical
//    training for young people who want to turn into
//    skillful .NET software engineers.</p></body>
//</html>

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameExtractContentFromHTML
{
    class ExtractContentFromHTML
    {
        static void Main()
        {
            bool isInsideTag = false;
            StringBuilder content = new StringBuilder();
            string html = @"<html>
<head><title>News</title></head>
<body><p><a href=""http://academy.telerik.com"">Telerik
Academy</a>aims to provide free real-world practical
training for young people who want to turn into
skillful .NET software engineers.</p></body>
</html>";
            for (int i = 0; i < html.Length; i++)
            {
               isInsideTag= GetCondition(html, i,isInsideTag);
               if (!isInsideTag)
               {
                   if (html[i]!='<' && html[i]!= '>')
                   {
                       content.Append(html[i]);
                   }
                   if (html[i] == '>')
                   {
                       content.Append(" ");
                   }
               }
               
            }
            html = content.ToString();
            string[] splitters = { " " };
            string[] split = html.Split(splitters,StringSplitOptions.RemoveEmptyEntries);
            StreamWriter writer = new StreamWriter("test.txt");
            using (writer)
            {
                for (int i = 0; i < split.Length; i++)
                {
                    writer.Write(split[i] + " ");
                }
            }
            for (int i = 0; i < split.Length; i++)
            {
                Console.Write(split[i]+" ");
            }
        }
        
        private static bool GetCondition(string str, int index, bool isInside)
        {
            if (isInside)
            {
                if (str[index]=='>')
                {
                    isInside = false;
                }
            }
            else
            {
                if (str[index]=='<')
                {
                    isInside = true;
                }
            }
            return isInside;
        }
    }
}
