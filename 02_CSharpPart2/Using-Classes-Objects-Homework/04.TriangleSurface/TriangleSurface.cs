/*
 * Problem 4. Triangle surface
 * Write methods that calculate the surface of a triangle by given:
 * Side and an altitude to it;
 * Three sides;
 * Two sides and an angle between them;
 * Use System.Math.
*/
using System;
class TriangleSurface
{
    static void SbySideAndHigh()
    {
        Console.Write("Please enter side C: ");
        decimal side = decimal.Parse(Console.ReadLine());

        Console.Write("Please enter hight C: ");
        decimal hight = decimal.Parse(Console.ReadLine());
                
        Console.WriteLine("The surface is: {0:F2}", (side * hight)/2.0m);
        
    }
    static void SbyThreeSides()
    {
        Console.Write("Please enter side A: ");
        decimal sideA = decimal.Parse(Console.ReadLine());

        Console.Write("Please enter side B: ");
        decimal sideB = decimal.Parse(Console.ReadLine());

        Console.Write("Please enter side C: ");
        decimal sideC = decimal.Parse(Console.ReadLine());

        decimal halfPerimeter = (sideA + sideB + sideC)/2.0m;

        Console.WriteLine("The surface is: {0:F2}", (decimal)Math.Sqrt(
            (double)(halfPerimeter*(halfPerimeter-sideA)*(halfPerimeter-sideB)*(halfPerimeter-sideC))
            ));      

    }
    static void SbySidesAndAngle()
    {
        Console.Write("Please enter side A: ");
        decimal sideA = decimal.Parse(Console.ReadLine());

        Console.Write("Please enter side B: ");
        decimal sideB = decimal.Parse(Console.ReadLine());

        Console.Write("Please enter Angle between A and B: ");
        decimal angle = decimal.Parse(Console.ReadLine());

        angle = (angle * (decimal)Math.PI) / 180.0m;
             
        Console.WriteLine("The surface is: {0:F2}", ((((decimal)Math.Sin((double)angle)) * sideA * sideB) / 2));
        
    }
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("This program will find a Triangle surface:");
            Console.WriteLine("1 --> Bu given side and an altitude to it");
            Console.WriteLine("2 --> By given Three sides");
            Console.WriteLine("3 --> By given Two sides and an angle between them");
            Console.WriteLine("4 --> Exit");

            Console.Write("User: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('-', 30));

            switch (number)
            {
                case 1: SbySideAndHigh(); break;
                case 2: SbyThreeSides(); break;
                case 3: SbySidesAndAngle(); break;
                case 4: return;

                default: Console.WriteLine("Invalid Input");
                    break;
            }
        }
    }
}

