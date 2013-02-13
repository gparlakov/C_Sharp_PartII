using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NameCensorForbiddenWords
{
    
    class CensorForbiddenWords
    {
        static void Main()
        {
            
            string[] dictionary = {"Microsoft","letter", "PHP", "soon"};
            String text = @"Microsoft announced its next generation PHP compiler today.It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR. A letter of confirmation was received today in our office. Soon we will be watching microsoft compete with a lot of other companies. ";
            Console.WriteLine("{0}\n",text);
            for (int i = 0; i < dictionary.Length; i++)
            {
                text = Censor.CensorWord(text, dictionary[i], new string('*', dictionary[i].Length));
            }
            Console.WriteLine(text);
        }
    }
}
