using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NameSevenSegmentDigits
{
    class SevenSegmentDigits
    {
        static List<string> combinations = new List<string>();
        static void Main()
        {
            
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            numbers.Add(126, 0);   //1111110 = 126
            numbers.Add(48, 1);    //0110000 = 48
            numbers.Add(109, 2);   //1101101 = 109
            numbers.Add(121, 3);   //1111001 = 121
            numbers.Add(51, 4);    //0110011 = 51
            numbers.Add(91, 5);    //1011011 = 91
            numbers.Add(95, 6);    //1011111 = 95
            numbers.Add(112, 7);   //1110000 = 112
            numbers.Add(127, 8);   //1111111 = 127
            numbers.Add(123, 9);   //1111011 = 123
            
            string sequence;
            List<List<string>> possibleNumbers = new List<List<string>>();
            
            
                
            //StreamReader reader = new StreamReader("test.txt");
            //using (reader)
            //{
                int count = int.Parse(Console.ReadLine());
                for (int i = 0; i < count; i++)
                {
                    sequence = Console.ReadLine();
                    possibleNumbers.Add(ExtractPossibleNums(sequence, numbers));
                }
            //}
            int allPossibleCombinations=1;
            for (int i = 0; i < possibleNumbers.Count; i++)
            {
                allPossibleCombinations *= possibleNumbers[i].Count;
            }
            Console.WriteLine(allPossibleCombinations);
            GetNext(possibleNumbers, 0, possibleNumbers.Count,"");
            for (int i = 0; i < combinations.Count; i++)
            {
                Console.WriteLine(combinations[i]);
            }
        }

        static void GetNext(List<List<string>> nums, int nextLevel, int depth,string soFar)
        {                       
            if (nextLevel == depth)
            {
                combinations.Add(soFar);
                return ;
            }           
            StringBuilder keepSoFar = new StringBuilder ();
            
            for (int i = 0; i < nums[nextLevel].Count; i++)
            {
                keepSoFar.Append(soFar);
                keepSoFar.Append(nums[nextLevel][i].ToString());
                GetNext(nums, nextLevel + 1, depth,keepSoFar.ToString());
                keepSoFar.Clear();
              
            }            
        }


        //I get the possible numbers by binary & with the given sequence 
        //so when I take 1110111
        //and & with     ????11?
        //I get the      0000110
        //this means I can use the 1110111 in the combination
        private static List<string> ExtractPossibleNums(string sequence, Dictionary<int, int> comparer)
        {
            int numberInSequence = GetNumber(sequence);
            List<string> result = new List<string>();

            foreach (var num in comparer)
            {
                if ((num.Key&numberInSequence)==numberInSequence)
                {
                    result.Add(comparer[num.Key].ToString());
                }
            }      
            return result;
        }
        
        //revert the number from binary to decimal
        static int GetNumber(string str)
        {
            int number = 0;
            for (int i = 0; i < str.Length; i++)
            {
                number += int.Parse(str[i].ToString()) * (int)Math.Pow(2,6-i);
            }
            return number;
        }

        
    }
}
