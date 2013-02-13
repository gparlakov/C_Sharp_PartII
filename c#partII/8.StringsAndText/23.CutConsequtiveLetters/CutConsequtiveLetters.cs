using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23.CutConsequtiveLetters
{
    class CutConsequtiveLetters
    {
        static void Main()
        {
            
            string sequence = "aaaabbbbcccdddddertrgtfgbgbbbbbbbbbbbbbbbbbbbbbbggggggggggggtrrrff";
            Console.WriteLine("Read a string from the console and replaces all series of consecutive identical letters with a single one. Example: \"aaaaabbbbbcdddeeeedssaa\"  \"abcdedsa\".");
            Console.WriteLine("Write sequence");
            sequence = Console.ReadLine();
            StringBuilder cleared = new StringBuilder();
            cleared.Append(sequence[0]);
            for (int i = 1; i < sequence.Length; i++)
            {
                if (sequence[i]!=cleared[cleared.Length-1])
                {
                    cleared.Append(sequence[i]);
                }
            }
            Console.WriteLine(cleared.ToString());
        }
    }
}
