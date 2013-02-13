using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameConvertToUnicodeChars
{
    class ConvertToUnicodeChars
    {
        static void Main()
        {
            string sentence = "Hi! A little short sentance is endong here.";
            for (int i = 0; i < sentence.Length; i++)
            {
                
                Console.Write("\\n{0:x4}",(int)sentence[i]);
            }
        }
    }
}
