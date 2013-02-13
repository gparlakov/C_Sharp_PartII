//Write a program that creates an array containing all letters from the alphabet (A-Z). 
//Read a word from the console and print the index of each of its letters in the array.


using System;

class AllIndexesOfCharsInAWord
{
    static void Main()
    {
        char[] chars = new char[26];
        for (int i = 0; i < 26; i++)
        {
            chars[i]=(char)(i+'A');
        }
        Console.WriteLine("Write the word:");
        string word = Console.ReadLine();
        
        //convert the word(s) to uppercase only
        word=word.ToUpper();

        //output the word's letters by index index 'A' = 1
        for (int i = 0; i < word.Length; i++)
        {
            Console.WriteLine("index of {0} is {1}",word[i],Array.IndexOf(chars,(char)word[i])+1);
        }
    }
}