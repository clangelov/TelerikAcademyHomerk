using System;

class Rectangles
{
    /* Problem 4. Rectangles
     * Write an expression that calculates rectangle’s perimeter and area by given width and height.
    */
    static void Main()
    {
        double width, height, perimeter, area;

        Console.Write("width = ");
        width = double.Parse(Console.ReadLine());
        Console.Write("height = ");
        height = double.Parse(Console.ReadLine());

        perimeter = 2 * (width + height);
        area = width * height;
        
        Console.WriteLine("The perimeter is: {0}", perimeter);
        Console.WriteLine("The area is: {0}", area);
    }
}

