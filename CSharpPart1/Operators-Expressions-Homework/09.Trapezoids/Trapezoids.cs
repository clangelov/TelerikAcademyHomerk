using System;
class Trapezoids
{
    static void Main()
    {
        double a, b, h, area;

        Console.Write("a = ");
        a = double.Parse(Console.ReadLine());
        Console.Write("b = ");
        b = double.Parse(Console.ReadLine());
        Console.Write("h = ");
        h = double.Parse(Console.ReadLine());

        area = ((a + b) / 2) * h;
        Console.WriteLine("Area = {0}", area);
    }
}

