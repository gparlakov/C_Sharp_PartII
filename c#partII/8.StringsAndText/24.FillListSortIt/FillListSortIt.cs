//Write a program that reads a list of words, separated by
//spaces and prints the list in an alphabetical order

using System;
using System.Collections.Generic;
using System.Linq;

namespace _24.FillListSortIt
{
    class FillListSortIt
    {
        static void Main()
        {
            List<string> strings = new List<string>();
            string row;
            
            do
            {
                Console.Write("Next(Enter Empty for end ):\t");
                row = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(row))
                {
                    strings.Add(row);
                }
            }
            while (!string.IsNullOrWhiteSpace(row));

            strings.Sort();
            Console.WriteLine("\nSorted case-insensitive");
            for (int i = 0; i < strings.Count; i++)
            {
                Console.WriteLine(strings[i]);
            }
            strings = OrderList(strings);
            Console.WriteLine("\nSorted case-sensitive");
            for (int i = 0; i < strings.Count; i++)
            {
                Console.WriteLine(strings[i]);
            }
        }

        static List<string> OrderList(List<string> stringList)
        {
            string temp;
            for (int i = 0; i < stringList.Count; i++)
            {
                for (int y = i; y < stringList.Count; y++)
                {
                    if (string.CompareOrdinal(stringList[i], stringList[y]) > 0)
                    {
                        temp = stringList[i];
                        stringList[i] = stringList[y];
                        stringList[y] = temp;
                    }
                }
            }
            return stringList;
        }
    }
}