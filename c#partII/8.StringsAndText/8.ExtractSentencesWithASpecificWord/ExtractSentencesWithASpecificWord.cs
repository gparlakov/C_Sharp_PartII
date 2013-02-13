//Write a program that extracts from a given text all sentences containing given word.
//        Example: The word is "in". The text is:

//We are living in a yellow submarine. We don't 
//have anything else. Inside the submarine is very
//tight. So we are drinking all the day. We will move out of it in 5 days.

//        The expected result is:
//We are living in a yellow submarine.
//We will move out of it in 5 days.
//        Consider that the sentences are separated by "." and the words – by non-letter symbols.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameExtractSentencesWithASpecificWord
{
    class ExtractSentencesWithASpecificWord
    {

        static string[] separators = new string[] { ".", "!", "?", };

        static void Main()
        {
            string text = @"We are living in a yellow submarine. We don't have in anything else. Inside the submarine is very tight. So we 
                            are drinking all the day. We will move out of it in 5 days.In we are drinking all the day. We will move out of it in 5 days.
                            Here are some more sentences without the word. And some more.So onnonnonononn. SomthINg is bad. Somethis is in there. Sometheing in.";
            List<string> sentences = GetSenteces(text);
            sentences = CheckRemoveSentences(sentences,"in");
            for (int i = 0; i < sentences.Count; i++)
            {
                Console.WriteLine(sentences[i]);
            }
        }

        private static List<string> CheckRemoveSentences(List<string> sentences, string p)
        {
            List<string> finalSentences = new List<string>();
            for (int i = 0; i < sentences.Count; i++)
            {
                if (ContainsWord(sentences[i],p))
                {
                    finalSentences.Add(sentences[i]);
                }
            }
            return finalSentences;
        }

        private static bool ContainsWord(string row, string word)
        {
            row = row.ToLower();
            word = word.ToLower();
            int startIndex=0;
            bool hasWord = false;
            do
            {
                startIndex = row.IndexOf(word,startIndex);

                if (startIndex < 0)
                {
                    break;
                }

                if (startIndex > 0 && startIndex + 2 < row.Length)
                {
                    if (!char.IsLetterOrDigit(row[startIndex - 1]) && !char.IsLetterOrDigit(row[startIndex + 2]))
                    {
                        return true;
                    }
                }
                else if (startIndex == 0 && !char.IsLetterOrDigit(row[startIndex + 2]))
                {
                    return true;
                }
                hasWord = false;
                startIndex++;
            } while (startIndex > 0);

            return hasWord;
        }

        private static List<string> GetSenteces(string text)
        {
            StringBuilder sentence = new StringBuilder();
            List<string> sentences= new List<string>();
            
            for (int i = 0; i < text.Length; i++)
            {
                sentence.Append(text[i]);
                if (text[i]=='.'||text[i]=='!'||text[i]=='?')
                {
                    
                    sentences.Add(sentence.ToString().Trim());
                    sentence.Clear();
                }
            }
            return sentences;
        }
    }
}
