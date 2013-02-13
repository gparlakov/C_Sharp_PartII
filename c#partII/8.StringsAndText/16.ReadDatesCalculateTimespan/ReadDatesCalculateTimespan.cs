//Write a program that reads two dates in the format: day.month.year
//and calculates the number of days between them. Example:
//Enter the first date: 27.02.2006//Enter the second date: 3.03.2004//Distance: 4 days

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.ReadDatesCalculateTimespan
{
    class ReadDatesCalculateTimespan
    {
        static void Main()
        {
            try
            {
                DateTime first, second;
                string date;
                string[] dateSplit;
                Console.WriteLine("First date:");
                date = Console.ReadLine();
                dateSplit = date.Split('.');
                first = new DateTime((int.Parse(dateSplit[2])), (int.Parse(dateSplit[1])), (int.Parse(dateSplit[0])));
                Console.WriteLine("Second date:");
                date = Console.ReadLine();
                dateSplit = date.Split('.');
                second = new DateTime((int.Parse(dateSplit[2])), (int.Parse(dateSplit[1])), (int.Parse(dateSplit[0])));
                if (first > second)
                {
                    DateTime temp = first;
                    first = second;
                    second = temp;
                }
                Console.WriteLine("There are {0:dd} days between {1:dd.MM.yyyy.} {2:dd.MM.yyyy.}", second - first, first, second);
                 
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("That date is wrong");
            }
            catch (FormatException)
            {
                Console.WriteLine("That date is wrong");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
