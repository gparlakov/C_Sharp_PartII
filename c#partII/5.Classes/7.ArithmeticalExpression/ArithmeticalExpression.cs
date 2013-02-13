﻿//* Write a program that calculates the value of given arithmetical expression.

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