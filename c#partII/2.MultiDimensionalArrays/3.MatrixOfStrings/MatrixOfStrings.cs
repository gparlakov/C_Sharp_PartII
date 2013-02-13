//We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbor elements located on the same line, column or diagonal.
//Write a program that finds the longest sequence of equal strings in the matrix. Example:
//ha	fifi	ho	hi
//fo	ha	hi	xx
//xxx	ho	ha	xx

//ha, ha, ha

//s	qq	s
//pp	pp	s
//pp	qq	s

//s, s, s

using System;

class MatrixOfStrings
{
    static void Main()
    {
        string[,] strings = {{"ha", "fifi", "fifi","fofi", "ha", "fifi", "fifi"},
                            {"ha",	  "ha",	"hi"  ,"fifi", "ha", "hi"  , "fifo"},
                            {"ha",    "hi", "i"   ,"fifi", "hi", "ha"  , "fifi"},
                            {"ha",    "hi", "ha"  ,"ha"  , "ha", "ha"  , "fifi"},
                            {"y",     "ha", "ha"  ,"ha"  , "ha", "ha"  , "fifi"}};
        int currentLenght = 0, maxLenght=int.MinValue;
        int rowString = 0, colString = 0,startingIndexX=0,startingIndexY=0;
        string maxString="",type="";
 
        for (int startingRow = 0; startingRow < strings.GetLength(0); startingRow++)
        {
            for (int startingCol = 0; startingCol < strings.GetLength(1); startingCol++)
            {
                //vertical Search
                for (rowString = startingRow; rowString < strings.GetLength(0); rowString++)
                {
                    if (strings[rowString,startingCol]==strings[startingRow,startingCol])
                    {
                        currentLenght++;                        
                    }
                    else
                    {
                        break;
                    }
                }
                if (currentLenght>maxLenght)
                {
                    maxLenght = currentLenght;
                    maxString = strings[startingRow, startingCol];
                    startingIndexX = startingRow;
                    startingIndexY = startingCol;
                    type = "vertical";
                }
                currentLenght = 0;

                //horizontal search 
                for (colString = startingCol; colString < strings.GetLength(1); colString++)
                {
                    if (strings[startingRow, startingCol] == strings[startingRow, colString])
                    {
                        currentLenght++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (currentLenght > maxLenght)
                {
                    maxLenght = currentLenght;
                    maxString = strings[startingRow, startingCol];
                    startingIndexX = startingRow;
                    startingIndexY = startingCol;
                    type = "horizontal";
                }
                currentLenght = 0;

                //diagonal search to the right
                rowString = startingRow;
                colString = startingCol;
                while (rowString < strings.GetLength(0) && colString < strings.GetLength(1))
                {
                    if (strings[rowString,colString]==strings[startingRow,startingCol])
                    {
                        currentLenght++;
                    }
                    else
                    {
                        break;
                    }
                    rowString++;
                    colString++;
                }
                if (currentLenght > maxLenght)
                {
                    maxLenght = currentLenght;
                    maxString = strings[startingRow, startingCol];
                    startingIndexX = startingRow;
                    startingIndexY = startingCol;
                    type = "rightDiagonal";
                }
                currentLenght = 0;

                //diagonal search to the left
                rowString = startingRow;
                colString = startingCol;
                while (rowString <strings.GetLength(0) && colString >= 0)
                {
                    if (strings[rowString, colString] == strings[startingRow, startingCol])
                    {
                        currentLenght++;
                    }
                    else
                    {
                        break;
                    }
                    rowString++;
                    colString--;
                }
                if (currentLenght > maxLenght)
                {
                    maxLenght = currentLenght;
                    maxString=strings[startingRow,startingCol];
                    startingIndexX = startingRow;
                    startingIndexY = startingCol;
                    type = "leftDiagonal";
                }
                currentLenght = 0;                
            }
            
        }
        for (int i = 0; i < maxLenght; i++)
        {
            Console.Write(maxString+ " ");
        }
        Console.WriteLine(type);
    }
}