using System;
class CirclePerimeterAndArea
{
    /* Problem 3. Circle Perimeter and Area
     * Write a program that reads the radius r of a circle and prints its perimeter and area formatted with 2 digits after the decimal point.
    */
    static void Main()
    {
        double radius, circumference, area;

        Console.Write("r = ");
        radius = double.Parse(Console.ReadLine());

        circumference = radius * (2 * Math.PI);

        area = Math.PI * (radius * radius);

        Console.WriteLine("the circumference is: {0:F2}", circumference);
        Console.WriteLine("the area is: {0:F2}", area);
    }
}

