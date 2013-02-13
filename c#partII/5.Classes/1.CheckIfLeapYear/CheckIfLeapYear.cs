//Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

using System;


namespace NameCheckIfLeapYear
{
    class CheckIfLeapYear
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("What year?");
                var checkedYear = new DateTime(int.Parse(Console.ReadLine()), 1, 1);
                Console.WriteLine("Is Leap {0}", DateTime.IsLeapYear(checkedYear.Year));

                Console.WriteLine("What year?");
                var checkedYear1 = new DateTime(int.Parse(Console.ReadLine()), 1, 1);
                Console.WriteLine("Is Leap {0}", DateTime.IsLeapYear(checkedYear1.Year));

                Console.WriteLine("What year?");
                var checkedYear2 = new DateTime(int.Parse(Console.ReadLine()), 1, 1);
                Console.WriteLine("Is Leap {0}", DateTime.IsLeapYear(checkedYear2.Year));

                Console.WriteLine("What year?");
                var checkedYear3 = new DateTime(int.Parse(Console.ReadLine()), 1, 1);
                Console.WriteLine("Is Leap {0}", DateTime.IsLeapYear(checkedYear3.Year));
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Nope - this is not a year");
            }
            catch (FormatException)
            {
                Console.WriteLine("Nope - this is not a year");
            }
        }
    }
}
