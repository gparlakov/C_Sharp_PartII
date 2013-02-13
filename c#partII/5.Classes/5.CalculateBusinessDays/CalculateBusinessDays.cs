//Write a method that calculates the number of workdays between today 
//and given date, passed as parameter. Consider that workdays are all days from Monday to Friday except
//a fixed list of public holidays specified preliminary as array.

using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace NameCalculateBusinessDays
{
    class CalculateBusinessDays
    {
        static void Main()
        {
            int day,month,businessDaysCounter=0,holidaysCounter=0;
            Holidays HolDays2013 = new Holidays();
            DateTime startingDate = DateTime.Now;
            DateTime endingDate = new DateTime();
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            do
            {
                try
                {
                    Console.WriteLine("whats the ending date?");
                    Console.WriteLine("Day:");
                    day = int.Parse(Console.ReadLine());
                    Console.WriteLine("Month:");
                    month = int.Parse(Console.ReadLine());
                    endingDate = new DateTime(2013, month, day);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nWrong input format\n");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("\nWrong input format\n");
                }
            

            
            } while (true);
            do
            {
                if (HolDays2013.IsWorkingDay(startingDate.Date))
                {
                    businessDaysCounter++;
                }
                else
                {
                    holidaysCounter++;
                }
                startingDate=startingDate.AddDays(1);
            } while (DateTime.Compare(startingDate.Date,endingDate.Date)<=0);

            Console.WriteLine("Working days from today to {0:dd MMMM yyyy}: {1} days\nHolidays(incl. Sundays and Saturdays) :{2} ",endingDate.Date,businessDaysCounter,holidaysCounter);
        }
    }
}
