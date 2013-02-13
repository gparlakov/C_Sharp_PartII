//Write a program that replaces in a HTML document 
//given as string all the tags <a href="…">…</a> with 
//corresponding tags [URL=…]…/URL]. Sample HTML fragment:

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace _15.RepleceAWithURL
{
    class RepleceAWithURL
    {
        static void Main()
        {
            int startIndex=0, endIndex;
            StringBuilder newHtml = new StringBuilder();
            bool url = true;
            string html = "<p>Please visit <a href=\"http://academy.telerik. com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p><p>Please visit <a href=\"http://academy.telerik. com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";
            do
            {
                endIndex = html.IndexOf("<a", startIndex);
                if (endIndex < 0)
                {
                    newHtml.Append(html.Substring(startIndex));
                    break;
                }
                newHtml.Append(html.Substring(startIndex, endIndex - startIndex));

                newHtml.Append("<URL");
                
                startIndex = endIndex + "<a href".Length;

                endIndex = html.IndexOf("</a", startIndex);
                if (endIndex < 0)
                {
                    break;
                }
                
                newHtml.Append(html.Substring(startIndex,endIndex - startIndex ));
                newHtml.Append("</URL>");
              
                startIndex += endIndex - startIndex+"</a>".Length;

            } while (true);

            Console.WriteLine(html);
            Console.WriteLine(newHtml);
        }
    }
}
