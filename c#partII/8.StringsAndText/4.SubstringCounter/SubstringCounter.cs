//Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).//        Example: The target substring is "in". The text is as follows://We are living in an yellow submarine. We don't have anything//else. Inside the submarine is very //tight. So we are drinking all the day. We will move out of it in 5 days.
//The result is: 9.

using System;

namespace NameSubstringCounter
{
    class SubstringCounter
    {
        static void Main()
        {
            string word = Console.ReadLine(); // "in";
            string allstring = Console.ReadLine();// "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";//Console.ReadLine();
            allstring.ToLower();
            int index = 0,counter=0;
            do
            {
                index = allstring.IndexOf(word, index);
                if (index>0)
                {
                    counter++;
                    index++;
                }      
            } while (index>0);
            Console.WriteLine("{0} {1} times",word,counter);
        }
    }
}
