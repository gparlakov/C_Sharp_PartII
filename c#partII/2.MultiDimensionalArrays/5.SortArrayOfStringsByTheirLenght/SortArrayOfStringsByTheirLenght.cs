using System;



class SortArrayOfStringsByTheirLenght
{
    static void Main()
    {
        String[] words = { "never", "first", "four", "key", "donatelo", "leona", "Just thought of it", "1", "13", "Very Big WOrddd", "Very Big WOrdddVery Big WOrddd" };
        int[] lengths = new int[words.Length];
        for (int i = 0; i < lengths.Length; i++)
        {
            lengths[i] = words[i].Length;
        }
        Array.Sort(lengths,words);
        for (int i = 0; i < words.Length; i++)
        {
            Console.WriteLine(words[i]);
        }
    }
}
