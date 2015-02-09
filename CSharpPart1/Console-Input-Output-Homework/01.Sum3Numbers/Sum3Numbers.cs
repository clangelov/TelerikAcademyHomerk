using System;

class Sum3Numbers
{
    /* Problem 1. Sum of 3 Numbers
    * Write a program that reads 3 real numbers from the console and prints their sum.
    */
    static void Main()
    {
        decimal a, b, c;

        Console.Write("a = ");
        a = decimal.Parse(Console.ReadLine());
        Console.Write("b = ");
        b = decimal.Parse(Console.ReadLine());
        Console.Write("c = ");
        c = decimal.Parse(Console.ReadLine());
                        
        Console.WriteLine("a + b + c = {0}", (a + b + c));
    }
}

