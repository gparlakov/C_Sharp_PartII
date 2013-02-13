//Write a program that reverses the words in given sentence.//    Example: "C# is not C++, not PHP and not Delphi!"  "Delphi not and PHP, not C++ not is C#!".

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.ReversWords
{
    class ReversWords
    {
        static void Main()
        {
            string sentence = "Hello C# again withe that same old sentence. But I say Basta. Let's turn things around!";
            int startIndex=0, nextIndex=0;
            StringBuilder reversed = new StringBuilder();
            for (nextIndex = 0; nextIndex < sentence.Length; nextIndex++)
            {

                if (sentence[nextIndex] == '.' || sentence[nextIndex] == '!' || sentence[nextIndex]=='?'|| char.IsWhiteSpace(sentence[nextIndex]))
                {
                    reversed.Append(ReverseStr(sentence.Substring(startIndex,nextIndex-startIndex)));
                    startIndex = nextIndex;
                }
                if (nextIndex==sentence.Length-1)
                {
                    reversed.Append(sentence[nextIndex]);
                }
                            
            }
            Console.WriteLine("{0}\n{1}",sentence,reversed);
        }

        static string ReverseStr(string str)
        {
            StringBuilder reversed = new StringBuilder();
            for (int i = str.Length-1; i >=0; i--)
            {
                reversed.Append(str[i]);
            }
            return reversed.ToString();
        }
    }
}
