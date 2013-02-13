using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameCalculateBusinessDays
{
    public class Holidays
    {
        readonly DateTime workingForChristmas = new DateTime(2013,12,14);
        public List<DateTime> holidays = new List<DateTime>();
        
        //private int year,month,day;
        public int Year{get;set;}
        public int Day { get; set; }
        public int Month { get; set; }

        public bool IsWorkingDay(DateTime date)
        {
            bool working = true;
            if ((date.DayOfWeek.ToString()=="Sunday" || date.DayOfWeek.ToString()=="Saturday") && date.Date != workingForChristmas.Date)
            {
                working = false;
            }
            else
            {
                foreach (var date2013 in holidays)
                {
                    if (date.Date==date2013.Date)
                    {
                        working = false;
                        break;
                    }
                }
            }

            return working;
        }


        public Holidays(int day, int month, int year)
        {
            this.Day = day;
            this.Month = month;
            this.Year = year;
            this.holidays.Add(new DateTime(Day, Month, Year = 2013));
        }

        public Holidays()
        {
            this.holidays.Add(new DateTime(2013, 1, 1));
            this.holidays.Add(new DateTime(2013, 1, 1));
            this.holidays.Add(new DateTime(2013, 5, 1));
            this.holidays.Add(new DateTime(2013, 5, 2));
            this.holidays.Add(new DateTime(2013, 5, 3));
            this.holidays.Add(new DateTime(2013, 5, 6));
            this.holidays.Add(new DateTime(2013, 5, 24));
            this.holidays.Add(new DateTime(2013, 9, 6));
            this.holidays.Add(new DateTime(2013, 11, 1));
            this.holidays.Add(new DateTime(2013, 12, 24));
            this.holidays.Add(new DateTime(2013, 12, 25));
            this.holidays.Add(new DateTime(2013, 12, 26));
            this.holidays.Add(new DateTime(2013, 12, 31));        
        }
    }
}
