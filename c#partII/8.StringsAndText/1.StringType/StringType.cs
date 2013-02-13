using System;


namespace NameStringType
{
    class StringType
    {
        //string is a readonly char array and can be concatenated with + and checked if is equal to another string
        static void Main(string[] args)
        {
            string row = "This is a line of text.And some more text.And that's it!";
            int length = row.Length; // gets the length of it
            char symbol = row[3];   //gets the symbol in that index
            //row.LastIndexOf();
            //row.IndexOf();        returns the firs index of a char or string from start or from given index onward

            row.Split(); //returns and array string[] split by some charachters given by programmer or default
            
            //string.Compare(str1,str2) returns value <0.==0.>0 by comparing the two strings letter by letter
            // if first letter is with a greater ascii code >0 / else <0 /else ==0
        }
        
        
    }
}
