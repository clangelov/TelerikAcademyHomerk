using System;
class BiggestOf5Numbers
{
    /* Problem 6. The Biggest of Five Numbers
     * Write a program that finds the biggest of five numbers by using only five if statements.
    */
    static void Main()
    {
        double a, b, c, d, e, biggest;

        Console.Write("a = ");
        a = double.Parse(Console.ReadLine());
        Console.Write("b = ");
        b = double.Parse(Console.ReadLine());
        Console.Write("c = ");
        c = double.Parse(Console.ReadLine());
        Console.Write("d = ");
        d = double.Parse(Console.ReadLine());
        Console.Write("e = ");
        e = double.Parse(Console.ReadLine());

        biggest = a;

        if (b > biggest)
        {
            biggest = b;
        }

        if (c > biggest)
        {
            biggest = c;
        }

        if (d > biggest)
        {
            biggest = d;
        }

        if (e > biggest)
        {
            biggest = e;
        }

        Console.WriteLine("The biggest number is {0}", biggest);
    }
}

