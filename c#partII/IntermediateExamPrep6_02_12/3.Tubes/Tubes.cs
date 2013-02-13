using System;
using System.Linq;
using System.IO;
 
namespace NameTubes
{
    class Tubes
    {
        static void Main()
        {

            ulong numberTubes, numberPeople;
            ulong workingLength = 0, counter = 0;
            ulong start = 0, end = 0;
            ulong totalTubesLenght = 0;
            //DateTime now = DateTime.Now;

            //StreamReader reader = new StreamReader("test.txt");
            //using (reader)
            //{
                numberTubes = ulong.Parse(Console.ReadLine());
                numberPeople = ulong.Parse(Console.ReadLine());
                ulong[] tubes = new ulong[numberTubes];
                for (ulong i = 0; i < numberTubes; i++)
                {
                    tubes[i] = ulong.Parse(Console.ReadLine());                    
                    totalTubesLenght += tubes[i];
                }
                workingLength = totalTubesLenght / numberPeople;
                start = 0;
                end = totalTubesLenght*2;
                if (workingLength <= 0)
                {
                    Console.WriteLine("-1");
                    return;
                }

                while (start+1<end)
                {
                    workingLength=start+(end-start)/2;
                    counter = 0;
                    for (int i = 0; i < tubes.Length; i++)
                    {
                        counter += tubes[i] / workingLength;
                    }
                    if (counter>=numberPeople)
                    {
                        start = workingLength;
                    }
                    else
                    {
                        end = workingLength;
                    }
                }
                //Console.WriteLine("{0:}",DateTime.Now-now);
                Console.WriteLine(start);

            //}
        }
    


        //private static ulong Count(ulong[] tubes, ulong workingLength)
        //{
        //    ulong counter = 0;
            
        //    return counter;
        //}
    }
}
