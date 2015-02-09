using System;
class PointInsideOutside 
{
    /* Problem 10. Point Inside a Circle & Outside of a Rectangle
     * Write an expression that checks for given point (x, y) if it is within the circle K({1, 1}, 1.5) and out of the rectangle R(top=1, left=-1, width=6, height=2).
    */
    static void Main()
    {
        double x, y, k;
        k = 1.5;
        Console.Write("x = ");
        x = double.Parse(Console.ReadLine());
        Console.Write("y = ");
        y = double.Parse(Console.ReadLine());

        bool inCircle = (((x - 1) * (x - 1) + (y -1 ) * (y - 1)) <= (k * k));
        bool outRectangle = (-1 < x) ^ (x > 5) ^ (-1 < y) ^ (y > 1);

        if (inCircle && outRectangle)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
          
    }
}

