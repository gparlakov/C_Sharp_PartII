//Write a program to check if in a given expression the brackets are put correctly.//Example of correct expression: ((a+b)/5-d).//Example of incorrect expression: )(a+b)).
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameBracketsChecker
{
    class BracketsChecker
    {
        static void Main(string[] args)
        {
            string row = Console.ReadLine();
            int brackets = 0;
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] == '(')
                {
                    brackets++;
                }
                else if (row[i] == ')')
                {
                    brackets--;
                }
                if (brackets<0)
                {
                    break;
                }
            }
            if (brackets == 0)
            {
                Console.WriteLine("The btrackets are OK");
            }
            else
            {
                Console.WriteLine("The brackets are out of order");
            }
        }
    }
}
