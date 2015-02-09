using System;

class PointInCircle
{
    /* Problem 7. Point in a Circle
     * Write an expression that checks if given point (x, y) is inside a circle K({0, 0}, 2).
    */
    static void Main()
    {
        double x, y, k;
        k = 2;
        Console.Write("x = ");
        x = double.Parse(Console.ReadLine());
        Console.Write("y = ");
        y = double.Parse(Console.ReadLine());

        bool inside = ((x * x + y * y) <= (k * k));
        Console.WriteLine("The point is inside the circle: {0}", inside);        
    }
}

