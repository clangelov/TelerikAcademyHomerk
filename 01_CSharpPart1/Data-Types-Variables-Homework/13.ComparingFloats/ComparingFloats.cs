using System;

class ComparingFloats
{
    /* Problem 13.* Comparing Floats
     * Write a program that safely compares floating-point numbers (double) with precision eps = 0.000001.
    */
    static void Main()
    {
        Console.WriteLine("Add your first number:");
        double a = (double.Parse(Console.ReadLine()));
        Console.WriteLine("Add your second number:");
        double b = (double.Parse(Console.ReadLine()));
        bool equalAB = Math.Abs(a - b) < 0.000001;
        Console.WriteLine("Are {0} and {1} equal?" + "\n" + "Answer: {2}", a, b, equalAB);
    }
}

