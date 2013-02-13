//* Write a program that calculates the value of given arithmetical expression.//The expression can contain the following elements only://Real numbers, e.g. 5, 18.33, 3.14159, 12.6//Arithmetic operators: +, -, *, / (standard priorities)//Mathematical functions: ln(x), sqrt(x), pow(x,y)//Brackets (for changing the default priorities)//    Examples://    (3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7)  ~ 10.6//    pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3)  ~ 21.22//    Hint: Use the classical "shunting yard" algorithm and "reverse Polish notation".

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameArithmeticalExpression
{
    class ArithmeticalExpression
    {
        static bool IsOperator(string str)
        {
            bool isOp = false;
            switch (str)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                case "(":
                case ")":
                case ",":
                case "ln":
                case "pow":
                    {
                        isOp = true;
                        break;
                    }

                default:
                    break;
            }            
            return isOp;
        }
        
        static void Main()
        {
            string expression = "(3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7)";
            StringBuilder next = new StringBuilder();
            List<string> operators = new List<string>(); 
            List<double> numbers = new List<double>();
            string nextString;
            double nextNum;

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] != ' ')
                {
                    next.Append(expression[i]);
                    if (IsOperator(next[next.Length - 1].ToString()))
                    {
                        if (next.Length > 1)
                        {
                            operators.Add(next[next.Length - 1].ToString());
                            next.Remove(next.Length - 1, 1);
                            nextString = next.ToString();
                            next.Clear();//clear the input cache
                            if (double.TryParse(nextString,out nextNum))
                            {
                                numbers.Add(nextNum);
                            }
                            else
                            {
                                operators.Insert(operators.Count-2,nextString);
                            }
                        }
                        else
                        {
                            operators.Add(next[0].ToString());
                            next.Clear();
                            continue;
                        }
                    }
                }
            }
        }
    }
}
