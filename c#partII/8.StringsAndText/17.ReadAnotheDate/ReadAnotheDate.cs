//Write a program that reads a date and time given in the format: day.month.year 
//hour:minute:second and prints the date and time after 6 hours and 30 minutes 
//(in the same format) along with the day of week in Bulgarian.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.ReadAnotheDate
{
    class ReadAnotheDate
    {
        static void Main()
        {
            try
            {
                DateTime datePrased;
                string date;
                string[] dateSplit;
                Console.WriteLine(" Date: day.month.year hour:minute:second Leave Empty for time=now");
                date = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(date))
                {
                    datePrased = DateTime.Now;
                }
                else
                {
                    dateSplit = date.Split('.', ':', ' ');
                    datePrased = new DateTime((int.Parse(dateSplit[2])), (int.Parse(dateSplit[1])), (int.Parse(dateSplit[0])), (int.Parse(dateSplit[3])), (int.Parse(dateSplit[4])), (int.Parse(dateSplit[5])));
                }
                datePrased = datePrased.AddHours(6.5);
                Console.WriteLine("After 6 hours 30 minutes will be {0:dd.MM.yyyy H:mm:ss}, {0:dddd}",datePrased);
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
