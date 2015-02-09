using System;
class Sort3Numbers
{
    /* Problem 7. Sort 3 Numbers with Nested Ifs
     * Write a program that enters 3 real numbers and prints them sorted in descending order.
     * Use nested if statements
     * Note: Don’t use arrays and the built-in sorting functionality.
    */
    static void Main()
    {
        double a, b, c;

        Console.Write("a = ");
        a = double.Parse(Console.ReadLine());
        Console.Write("b = ");
        b = double.Parse(Console.ReadLine());
        Console.Write("c = ");
        c = double.Parse(Console.ReadLine());

        if (a > b && a > c)
        {
            if (b > c)
            {
                Console.WriteLine("Sorted Numbers: {0} {1} {2}", a, b, c);
            }
            else
            {
                Console.WriteLine("Sorted Numbers: {0} {2} {1}", a, b, c);
            }
        }
        else if (b > a && b > c)
        {
            if (a > c)
            {
                Console.WriteLine("Sorted Numbers: {1} {0} {2}", a, b, c);
            }
            else
            {
                Console.WriteLine("Sorted Numbers: {1} {2} {0}", a, b, c);
            }
        }
        else
        {
            if (a > b)
            {
                Console.WriteLine("Sorted Numbers: {2} {0} {1}", a, b, c);
            }
            else
            {
                Console.WriteLine("Sorted Numbers: {2} {1} {0}", a, b, c);
            }
        }
    }
}

