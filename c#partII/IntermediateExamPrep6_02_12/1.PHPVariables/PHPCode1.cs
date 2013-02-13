using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NamePHPCode1
{
    class PHPCode1
    {
        static bool insideString1 = false;
        static bool insideString2 = false;
        static bool insideComment = false;
        static bool insideCommentRow=false;
        static List<string> variables = new List<string>();

        static void Main()
        {
            string row;//= Console.ReadLine();
            
            //StreamReader reader = new StreamReader("test.txt");
            //using (reader)
            //{
                do
                {
                    row = Console.ReadLine();
                    if (row=="?>"||row==null)
                    {
                        break;
                    }
                    ExtractVariables(row, variables);
                } while (true);
            //}
            variables = OrderList(variables); 
                //variables.OrderBy( (List<string> x, List<string> y) => x.ToString().CompareTo(y.ToString());
            Console.WriteLine(variables.Count);
            for (int i = 0; i < variables.Count; i++)
            {
                Console.WriteLine(variables[i]);
            }

        }

        private static void ExtractVariables(string row, List<string> variables)
        {
            char nextSymbol;
            string temp;
            if (insideCommentRow == true)
            {
                insideCommentRow = false;
            }
            if (insideString1)
            {
                insideString1 = false;
            }
            if (insideString2)
            {
                insideString2 = false;
            }
            for (int i = 0; i < row.Length; i++)
            {                
                nextSymbol = row[i];
                GetCondition(row, i);
                if (nextSymbol == '$')
                {
                    if (insideComment||insideCommentRow)
                    {
                        continue;
                    }
                    temp = GetVariable(insideString1, insideString2, row, i);
                    if (variables.IndexOf(temp) < 0 && !String.IsNullOrWhiteSpace(temp))
                    {
                        variables.Add(temp); 
                    } 
                }
            }
        }

        private static string GetVariable(bool insideString1,bool insideString2, string row, int i)
        {
            string var=null;
            if (insideString1||insideString2)
            {
                if (IsInsideArray(row, i - 1))
                {
                    if (row[i - 1] != '\\')
                    {
                        var = VarExtractor(row, i);
                    }
                }
            }
            else
            {
                var = VarExtractor(row, i);
            }
            return var;
        }

        private static string VarExtractor(string row, int i)
        {
            StringBuilder tempVar = new StringBuilder();
            while (IsInsideArray(row,i+1))
            {
                if (row[i+1]=='_'||char.IsLetterOrDigit(row[i+1]))
                {
                    tempVar.Append(row[i + 1]);
                }
                else
                {
                    break;
                }
                i++;
            }
            return tempVar.ToString();
        }

        private static void GetCondition(string row, int i)
        {
            if (insideComment)
            {
                if (i - 1 >= 0 && row[i - 1] == '*' && row[i] == '/')
                {
                    insideComment = false;
                }
            }
            else
            {
                if (row[i] == '#')
                {
                    insideCommentRow = true;
                }
                else
                {
                    if (IsInsideArray(row, i + 1))
                    {
                        if (row[i] == '/' && row[i + 1] == '/' && !insideString1 && !insideString2)
                        {
                            insideCommentRow = true;
                        }
                        else if (row[i] == '/' && row[i + 1] == '*' && !insideString1 && !insideString2)
                        {
                            insideComment = true;
                        }
                    }
                }

                if (insideString1)
                {
                    if (row[i] == '\'')
                    {
                        if (IsInsideArray(row, i - 1))
                        {
                            if (row[i - 1] != '\\')
                            {
                                insideString1 = false;
                            }
                        }
                    }
                }
                else
                {
                    if (!insideString2)
                    {
                        if (row[i]=='\'')
                        {
                            insideString1 = true;
                        }
                    }
                    
                }

                if (insideString2)
                {
                    if (row[i] == '"')
                    {
                        if (IsInsideArray(row, i - 1))
                        {
                            if (row[i - 1] != '\\')
                            {
                                insideString2 = false;
                            }
                        }
                    }
                }
                else
                {
                    if (row[i]=='"'&&!insideString1)
                    {
                        insideString2 = true;
                    }
                }
            }

        }

        static bool IsInsideArray(string str, int index)
        {
            if (index >= str.Length || index < 0)
            {
                return false;
            }
            return true;
        }

        static List<string> OrderList(List<string> stringList)
        {
            
            string temp;
            for (int i = 0; i < stringList.Count; i++)
            {                
                for (int y = i; y < stringList.Count; y++)
                {
                    if (string.CompareOrdinal(stringList[i],stringList[y]) > 0)
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
