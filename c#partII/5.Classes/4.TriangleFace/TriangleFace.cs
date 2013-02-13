//Write methods that calculate the surface of a triangle by given://Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.
using System;
using System.Threading;

namespace NameTriangleFace
{
    class TriangleFace
    {
        static void SurfaceBySideAltitude()
        {
            int side, altitude;
            Console.WriteLine("Side:");
            side = int.Parse(Console.ReadLine());
            Console.WriteLine("Altitude:");
            altitude = int.Parse(Console.ReadLine());
            Console.WriteLine("Face is  {0} m2",side*altitude/2);
        }

        static void SurfaceByThreeSides()
        {
            int side1, side2, side3;
            float perimeter;
            Console.WriteLine("Side1:");
            side1 = int.Parse(Console.ReadLine());            
            Console.WriteLine("Side2:");
            side2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Side3:");
            side3 = int.Parse(Console.ReadLine());
            perimeter = (float)((side1 + side2 + side3)/2);
            Console.WriteLine("Face is  {0} m2", Math.Sqrt((perimeter * (perimeter - side1) * (perimeter - side2) * (perimeter - side3))));
        }

        static void SurfaceByTwoSidesAndAngle()
        {
            int side1, side2,angle;            
            Console.WriteLine("Side1:");
            side1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Side2:");
            side2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Angle in degrees :");
            angle = int.Parse(Console.ReadLine());
            angle = angle%360;
            Console.WriteLine("Face is {0:f} m2",Math.Sin(angle*Math.PI/180) * side1 * side2 / 2);
        }
        
        static void Main()
        {
            do
            {
                Console.WriteLine("What method shall we use to find the triangle surface by?");
                Console.WriteLine("1. Side and altitude to it");
                Console.WriteLine("2. Three sides");
                Console.WriteLine("3. Two sides and an angle between them");
                Console.WriteLine("4. Exit");

                try
                {

                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            {
                                Console.Clear();
                                SurfaceBySideAltitude();
                                Thread.Sleep(4000);
                                Console.Clear();
                                break;
                            }
                        case 2:
                            {
                                Console.Clear();
                                SurfaceByThreeSides();
                                Thread.Sleep(4000);
                                Console.Clear();
                                break;
                            }
                        case 3:
                            {
                                Console.Clear();
                                SurfaceByTwoSidesAndAngle();
                                Thread.Sleep(4000);
                                Console.Clear();
                                break;
                            }
                        case 4:
                            return;
                        default:
                            Console.Clear();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong input format");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                
            } while (true);
        }
    }
}
