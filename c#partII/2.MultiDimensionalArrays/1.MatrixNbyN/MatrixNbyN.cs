//Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)
//1	5	9	13  Numbers1          
//2	6	10	14              
//3	7	11	15              
//4	8	12	16              

//1	8	9	16  Numbers2
//2	7	10	15
//3	6	11	14
//4	5	12	13

//7	11	14	16  Numbers3 
//4	8	12	15
//2	5	9	13
//1	3	6	10

//1	12	11	10  Numbers4 
//2	13	16	9
//3	14	15	8
//4	5	6	7




using System;

class MatrixNbyN
{
    static void Main(string[] args)
    {
        string number;//=9; //works fine for  under 100 
        int n=0;
        do
        {
            Console.WriteLine("How big mAtrix?");
            number = Console.ReadLine();
        }while(!int.TryParse(number,out n)||n<1);
        
        int index = 1, row = 0, col = 0, modifier = 1;
        int[,] numbers1 = new int[n, n];
        int[,] numbers2 = new int[n, n];
        int[,] numbers3 = new int[n, n];
        int[,] numbers4 = new int[n, n];

        //first
        index = 1;
        row = 0;
        col = 0;
        modifier = 1;
        do
        {
            numbers1[row, col] = index;
            row++;
            if (row == n)
            {
                row = 0;
                col++;
            }
            index++;
        } while (index <= n * n);

        //second
        index = 1;
        row = 0;
        col = 0;
        modifier = 1;
        do
        {
            numbers2[row, col] = index;
            row += modifier;
            
            if(row==n||row==-1)
            {
                modifier *= -1;
                row += modifier;
                col++;
            }
            index++;
        } while (index<=n*n);


        //third
        index = 1;
        row = n-1;
        col = 0;
        modifier = 1;
        int bigModifier = 1;

        bool start = true;
        int iterations = 0;
        do
        {
            numbers3[row, col] = index;     
            index++;
            iterations++;

            if (iterations == bigModifier)
            {

                if (start)
                {
                    row -= bigModifier;
                    col -= bigModifier - 1;
                }
                else
                {
                    row -= bigModifier - 1;
                    col -= bigModifier - 2;
                }
                
                bigModifier += modifier;
                if (bigModifier == n)
                {
                    modifier = -1;
                    start = false;
                }
                iterations = 0;
            }
            else
            {
                row++;
                col++;
            }
        } while (index <= n * n);

        //fourth
        for (int i = 0; i < n; i++)
        {
            numbers4[i, 0] = i+1;
        }
        index = n+1;
        row = n-1;
        col = 0;        
        modifier = n-1;
        iterations = 0;

        int rowModify = -1;
        int colModify = 1;
       
        
        do
        {
            for (int i = 0; i < modifier; i++)
            {
                col += colModify;
                numbers4[row, col] = index;
                index++;
                
            }
            
            for (int i = 0; i < modifier;i++ )
            {
                row += rowModify;
                numbers4[row, col] = index;
                index++;
                
            }
            
            
            
            rowModify *= -1;
            colModify *= -1;
            modifier--;
               
        } while (index <= n * n);


        Console.WriteLine("First Matrix");
        for (int x = 0; x < n; x++)
        {
            Console.Write("|"); 
            for (int y = 0; y < n; y++)
            {
                Console.Write("{0}|", numbers1[x, y]);
            }
            Console.WriteLine(" >");
        }
        Console.WriteLine();

        Console.WriteLine("Second Matrix");
        for (int x = 0; x < n; x++)
        {
            Console.Write("|");
            for (int y = 0; y < n; y++)
            {
                Console.Write("{0}|", numbers1[x, y]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        Console.WriteLine("Third Matrix");
        for (int x = 0; x < n; x++)
        {

            Console.Write("|");
            for (int y = 0; y < n; y++)
            {
                Console.Write("{0}|", numbers1[x, y]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        Console.WriteLine("Fourth Matrix");
        for (int x = 0; x < n; x++)
        {
            Console.Write("|");
            for (int y = 0; y < n; y++)
            {
                Console.Write("{0}|", numbers1[x, y]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    
}

