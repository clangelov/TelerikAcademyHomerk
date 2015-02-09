using System;
class BiggestOf3Numbers
{
    /* Problem 5. The Biggest of 3 Numbers
     * Write a program that finds the biggest of three numbers.
    */
    static void Main()
    {
        double a, b, c, biggest;
        
        Console.Write("a = ");
        a = double.Parse(Console.ReadLine());
        Console.Write("b = ");
        b = double.Parse(Console.ReadLine());
        Console.Write("c = ");
        c = double.Parse(Console.ReadLine());

        biggest = Math.Max(a, b);

        if (biggest <= c)
        {
            biggest = c;
        }
        Console.WriteLine("The biggest number is {0}", biggest);
    }
}

